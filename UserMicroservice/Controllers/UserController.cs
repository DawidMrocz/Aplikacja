using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Claims;
using UserMicroserivce.Commands;
using UserMicroserivce.Dtos;
using UserMicroserivce.Queries;
using UserMicroservice.Dtos;
using UserMicroservice.Entities;
using UserMicroservice.Models;

namespace UserMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UserDbContext _context;

        public UserController(IMediator mediator,UserDbContext context)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _context = context ?? throw new ArgumentNullException(nameof(context));

                 
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetUsers()
        {
            return Ok(await _context.Users.ToListAsync());
        }


        [HttpGet("/profile", Name = "GetProfile")]
        [Authorize]
        [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<UserDto>> GetUser()
        {
            try
            {
                GetProfileQuery command = new GetProfileQuery()
                {
                    UserId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value)
                };
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Register")]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> RegisterUser([FromBody] CreateUserCommand command)
        {
            try
            {
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(String), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<String>> LoginUser([FromBody] LoginUserQuery command)
        {
            try
            {
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("/profile")]
        [Authorize]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DeleteUser()
        {
            try
            {
                DeleteUserCommand command = new DeleteUserCommand()
                {
                    UserId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value)
            };
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/profile")]
        [Authorize]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> UpdateUser([FromBody] UpdateDto updateUser)
        {
            try
            {
                UpdateUserCommand command = new UpdateUserCommand()
                {
                    UserId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value),
                    Name = updateUser.Name,
                    Email = updateUser.Email,
                    CCtr = updateUser.CCtr,
                    ActTyp = updateUser.ActTyp,
                    Photo = updateUser.Photo,
                };
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}