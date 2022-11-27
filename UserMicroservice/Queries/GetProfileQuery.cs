using AutoMapper;
using MediatR;
using UserMicroservice.Dtos;
using UserMicroservice.Repositories;

namespace UserMicroserivce.Queries
{
    public record GetProfileQuery : IRequest<UserDto>
    {
        public int UserId { get; set; }
    }
    public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public GetProfileQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<UserDto> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetProfile(request);
        }
    }
}