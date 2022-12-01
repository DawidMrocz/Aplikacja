using AutoMapper;
using MassTransit;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserMicroserivce;
using UserMicroserivce.Commands;
using UserMicroserivce.Queries;
using UserMicroservice.Contracts.InboxContracts;
using UserMicroservice.Dtos;
using UserMicroservice.Entities;
using UserMicroservice.GrpcService;
using UserMicroservice.Models;

namespace UserMicroservice.Repositories
    {
        public class UserRepository : IUserRepository
        {
            private readonly UserDbContext _context;
            private readonly IMapper _mapper;
            private readonly IPasswordHasher<User> _passwordHasher;
            private readonly IDistributedCache _cache;
            private readonly AuthenticationSettings _authenticationSettings;
            private readonly IPublishEndpoint _publishEndpoint;
            private readonly IUserGrpcService _userGrpcService;

        public UserRepository(
            UserDbContext context,
            IMapper mapper,
            IPasswordHasher<User> passwordHasher,
            IDistributedCache cache,
            AuthenticationSettings authenticationSettings,
            IPublishEndpoint publishEndpoint,
            IUserGrpcService userGrpcService
            )
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
                _cache = cache ?? throw new ArgumentNullException(nameof(cache));
                _authenticationSettings = authenticationSettings ?? throw new ArgumentNullException(nameof(authenticationSettings));
                _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
                _userGrpcService = userGrpcService ?? throw new ArgumentNullException(nameof(userGrpcService));
            }

            public async Task<UserDto> GetProfile(GetProfileQuery command)
            {
                User? profile = await _cache.GetRecordAsync<User>($"Profile_{command.UserId}");
                if (profile is null)
                {
                    profile = await _context.Users.AsNoTracking().SingleAsync(p => p.UserId == command.UserId);
                    await _cache.SetRecordAsync($"Profile_{command.UserId}", profile);
                }
                return _mapper.Map<UserDto>(profile);
            }
            public async Task<User> CreateUser(CreateUserCommand command)
            {
                var newUser = new User()
                {
                    Name = command.Name,
                    Email = command.Email,
                    ActTyp = command.ActTyp,
                    CCtr = command.CCtr,
                    Photo = command.Photo,
                    Role = "User",
                };
                newUser.PasswordHash = _passwordHasher.HashPassword(newUser, command.Password);
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
                await _publishEndpoint.Publish(new CreateUserInbox(newUser.UserId, newUser.Name,newUser.Photo,newUser.CCtr,newUser.ActTyp));
                await _userGrpcService.CreateUserCats(newUser.UserId,newUser.Name, newUser.CCtr, newUser.ActTyp);
                return newUser;
            }

            public async Task<String> LoginUser(LoginUserQuery command)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == command.Email);
                if (user is null) throw new BadHttpRequestException("Bad");
                var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, command.Password);
                if (result == PasswordVerificationResult.Failed) throw new BadHttpRequestException("Bad");
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                    new Claim(ClaimTypes.Name,user.Name),
                    new Claim(ClaimTypes.Role,user.Role),
                    new Claim("CCtr", user.CCtr.ToString()),
                    new Claim("ActTyp", user.ActTyp.ToString()),
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
                var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);
                var token = new JwtSecurityToken(
                    _authenticationSettings.JwtIssuer,
                    _authenticationSettings.JwtIssuer,
                    claims,
                    expires: expires,
                    signingCredentials: cred
                );
                var tokenHandler = new JwtSecurityTokenHandler();
                return tokenHandler.WriteToken(token);
            }
            public async Task<bool> DeleteUser(DeleteUserCommand command)
            {
                var myProfile = await _context.Users.SingleAsync(r => r.UserId == command.UserId);
                if (myProfile is null) throw new BadHttpRequestException("Bad");
                await _cache.DeleteRecordAsync<User>($"Profile_{command.UserId}");
                _context.Remove(myProfile);
                await _context.SaveChangesAsync();
                await _publishEndpoint.Publish(new DeleteUserInbox(myProfile.UserId));
                await _userGrpcService.DeleteUserCats(myProfile.UserId);
            return true;
            }

            public async Task<User> UpdateUser(UpdateUserCommand command)
            {
                var currentUser = await _context.Users.SingleAsync(r => r.UserId == command.UserId);
                if (currentUser is null) throw new BadHttpRequestException("Bad");
                currentUser.Name = command.Name;
                currentUser.Email = command.Email;
                currentUser.CCtr = command.CCtr;
                currentUser.ActTyp = command.ActTyp;
                currentUser.Photo = command.Photo;

            await _cache.DeleteRecordAsync<User>($"Profile_{command.UserId}");
                _context.SaveChanges();
            await _userGrpcService.UpdateUserCats(currentUser.UserId, currentUser.Name, currentUser.CCtr, currentUser.ActTyp);
            await _publishEndpoint.Publish(new UpdateUserInbox(currentUser.UserId, currentUser.Name, currentUser.Photo, currentUser.CCtr, currentUser.ActTyp));
            return currentUser;
            }

        public Task<string> ForgotPassword()
        {
            throw new NotImplementedException();
        }

        public Task<string> ChangePassword()
        {
            throw new NotImplementedException();
        }

        public Task<string> ChangeRole()
        {
            throw new NotImplementedException();
        }
    }
    }
