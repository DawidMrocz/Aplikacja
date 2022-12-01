using InboxMicroservice.Entities;
using InboxMicroservice.Repositories;
using MediatR;

namespace InboxMicroservice.Commands.InboxItemCommands
{
    public record DeleteInboxItemFromInboxCommand : IRequest<bool>
    {
        public int UserId { get; set; }
        public int InboxItemId { get; set; }
    }
    public class DeleteInboxItemFromInboxCommandHandler : IRequestHandler<DeleteInboxItemFromInboxCommand, bool>
    {
        private readonly IInboxRepository _inboxRepository;

        public DeleteInboxItemFromInboxCommandHandler(IInboxRepository inboxRepository)
        {
            _inboxRepository = inboxRepository ?? throw new ArgumentNullException(nameof(inboxRepository));
        }

        public async Task<bool> Handle(DeleteInboxItemFromInboxCommand request, CancellationToken cancellationToken)
        {
            return await _inboxRepository.DeleteInboxItemFromInbox(request);
        }
    }
}