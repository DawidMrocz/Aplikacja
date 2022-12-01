
using MediatR;
using UserMicroservice.Dtos;
using UserMicroservice.Repositories;

namespace UserMicroserivce.Queries
{
    public record LoginUserQuery : IRequest<String>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, String>
    {
        private readonly IUserRepository _userRepository;

        public LoginUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<String> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.LoginUser(request);
        }
    }
}