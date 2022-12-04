using InboxMicroservice.Entities;
using InboxMicroservice.Repositories;
using MediatR;

namespace InboxMicroservice.Commands.InboxItemCommands
{
    public record UpdateJobFromInboxCommand : IRequest<InboxItem>
    {
        public int UserId { get; set; }
        public int InboxItemId { get; set; }
        public string Status { get; set; }
        public int Components { get; set; }
        public int DrawingsComponents { get; set; }
        public int DrawingsAssembly { get; set; }
        public string? WhenComplete { get; set; }
        public string? Started { get; set; }
        public string? Finished { get; set; }
    }
    public class UpdateInboxItemFromInboxCommandHandler : IRequestHandler<UpdateJobFromInboxCommand, InboxItem>
    {
        private readonly IInboxRepository _inboxRepository;

        public UpdateInboxItemFromInboxCommandHandler(IInboxRepository inboxRepository)
        {
            _inboxRepository = inboxRepository ?? throw new ArgumentNullException(nameof(inboxRepository));
        }

        public async Task<InboxItem> Handle(UpdateJobFromInboxCommand request, CancellationToken cancellationToken)
        {
            return await _inboxRepository.UpdateJobFromInbox(request);
        }
    }
}