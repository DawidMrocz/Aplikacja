using InboxMicroservice.Entities;
using InboxMicroservice.Repositories;
using MediatR;

namespace InboxMicroservice.Commands.InboxItemCommands
{
    public record DeleteUserJobFromInboxCommand : IRequest<bool>
    {
        public int UserId { get; set; }
        public int InboxItemId { get; set; }
    }
    public class DeleteInboxItemFromInboxCommandHandler : IRequestHandler<DeleteUserJobFromInboxCommand, bool>
    {
        private readonly IInboxRepository _inboxRepository;

        public DeleteInboxItemFromInboxCommandHandler(IInboxRepository inboxRepository)
        {
            _inboxRepository = inboxRepository ?? throw new ArgumentNullException(nameof(inboxRepository));
        }

        public async Task<bool> Handle(DeleteUserJobFromInboxCommand request, CancellationToken cancellationToken)
        {
            return await _inboxRepository.DeleteUserJobFromInbox(request);
        }
    }
}