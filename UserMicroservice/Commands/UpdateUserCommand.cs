using AutoMapper;
using MediatR;
using UserMicroservice.Dtos;
using UserMicroservice.Repositories;

namespace UserMicroserivce.Commands
{
    public record UpdateUserCommand : IRequest<UserDto>
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Photo { get; set; }
        public string Email { get; set; }
        public string CCtr { get; set; }
        public string ActTyp { get; set; }
    }
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var updatedUser = await _userRepository.UpdateUser(request);
            return _mapper.Map<UserDto>(updatedUser);
        }
    }
}