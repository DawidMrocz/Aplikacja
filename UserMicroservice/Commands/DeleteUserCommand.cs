using MediatR;
using UserMicroservice.Repositories;

namespace UserMicroserivce.Commands
{
    public record DeleteUserCommand : IRequest<bool>
    {
        public int UserId { get; set; }
    }
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteUser(request);
            return true;
        }
    }

}