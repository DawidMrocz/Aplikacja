using Microsoft.AspNetCore.Mvc;
using UserMicroserivce.Commands;
using UserMicroserivce.Dtos;
using UserMicroserivce.Queries;
using UserMicroservice.Dtos;
using UserMicroservice.Entities;

namespace UserMicroservice.Repositories
{
    public interface IUserRepository
    {
        public Task<UserDto> GetProfile(GetProfileQuery command);
        public Task<String> LoginUser(LoginUserQuery command);
        public Task<User> CreateUser(CreateUserCommand command);
        public Task<bool> DeleteUser(DeleteUserCommand command);
        public Task<User> UpdateUser(UpdateUserCommand command);
    }
}