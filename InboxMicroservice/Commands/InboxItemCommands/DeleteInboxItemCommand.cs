using InboxMicroservice.Repositories;
using MediatR;

namespace InboxMicroservice.Commands.InboxItemCommands
{
    public record DeleteInboxItemCommand : IRequest<bool>
    {
        public int JobId { get; set; }
    }
    public class DeleteInboxItemCommandHandler : IRequestHandler<DeleteInboxItemCommand, bool>
    {
        private readonly IInboxRepository _inboxRepository;

        public DeleteInboxItemCommandHandler(IInboxRepository inboxRepository)
        {
            _inboxRepository = inboxRepository ?? throw new ArgumentNullException(nameof(inboxRepository));
        }

        public async Task<bool> Handle(DeleteInboxItemCommand request, CancellationToken cancellationToken)
        {
            return await _inboxRepository.DeleteInboxItem(request);
        }
    }
}