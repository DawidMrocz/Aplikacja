using AutoMapper;
using UserMicroservice.Entities;

namespace UserMicroservice.Dtos
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}