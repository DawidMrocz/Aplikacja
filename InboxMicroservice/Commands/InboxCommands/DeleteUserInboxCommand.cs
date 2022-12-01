
using InboxMicroservice.Repositories;
using MediatR;

namespace InboxMicroservice.Commands.InboxCommands
{
    public record DeleteUserInboxCommand : IRequest<bool>
    {
        public int UserId { get; set; }
    }
    public class DeleteUserInboxCommandHandler : IRequestHandler<DeleteUserInboxCommand, bool>
    {
        private readonly IInboxRepository _inboxRepository;

        public DeleteUserInboxCommandHandler(IInboxRepository inboxRepository)
        {
            _inboxRepository = inboxRepository ?? throw new ArgumentNullException(nameof(inboxRepository));
        }

        public async Task<bool> Handle(DeleteUserInboxCommand request, CancellationToken cancellationToken)
        {
            return await _inboxRepository.DeleteUserInbox(request);
        }
    }
}