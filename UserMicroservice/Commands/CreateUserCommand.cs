using AutoMapper;
using MediatR;
using UserMicroservice.Dtos;
using UserMicroservice.Repositories;

namespace UserMicroserivce.Commands
{
    public record CreateUserCommand : IRequest<UserDto>
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public string CCtr { get; set; }
        public string ActTyp { get; set; }
    }
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return _mapper.Map<UserDto>(await _userRepository.CreateUser(request));
        }
    }
}