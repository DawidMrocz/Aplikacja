using InboxMicroservice.Entities;
using InboxMicroservice.Repositories;
using MediatR;

namespace InboxMicroservice.Commands.InboxItemCommands
{
    public record UpdateInboxItemCommand : IRequest<InboxItem>
    {
        public int InboxItemId { get; set; }
        public int Hours { get; set; }
        public string Status { get; set; }
        public int Components { get; set; }
        public int DrawingsComponents { get; set; }
        public int DrawingsAssembly { get; set; }
        public string? WhenComplete { get; set; }
        public string? Started { get; set; }
        public string? Finished { get; set; }
    }
    public class UpdateInboxItemCommandHandler : IRequestHandler<UpdateInboxItemCommand, InboxItem>
    {
        private readonly IInboxRepository _inboxRepository;

        public UpdateInboxItemCommandHandler(IInboxRepository inboxRepository)
        {
            _inboxRepository = inboxRepository ?? throw new ArgumentNullException(nameof(inboxRepository));
        }

        public async Task<InboxItem> Handle(UpdateInboxItemCommand request, CancellationToken cancellationToken)
        {
            return await _inboxRepository.UpdateInboxItem(request);
        }
    }
}