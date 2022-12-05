using InboxMicroservice.Entities;
using InboxMicroservice.Repositories;
using MediatR;

namespace InboxMicroservice.Commands.FromJobsCommands
{
    public record CreateInboxItemFromJobCommand : IRequest<InboxItem>
    {
        public int UserId { get; set; }
        public int JobId { get; set; }
        public string JobDescription { get; set; }
        public string Type { get; set; }
        public string System { get; set; }
        public string Link { get; set; }
        public string Engineer { get; set; }
        public int Ecm { get; set; }
        public int Gpdm { get; set; }
        public string ProjectNumber { get; set; }
        public string Client { get; set; }
        public string ProjectName { get; set; }
        public string Status { get; set; }
        public string Received { get; set; }
        public string? DueDate { get; set; }
    }
    public class CreateInboxItemFromJobCommandHandler : IRequestHandler<CreateInboxItemFromJobCommand, InboxItem>
    {
        private readonly IInboxRepository _inboxRepository;

        public CreateInboxItemFromJobCommandHandler(IInboxRepository inboxRepository)
        {
            _inboxRepository = inboxRepository ?? throw new ArgumentNullException(nameof(inboxRepository));
        }

        public async Task<InboxItem> Handle(CreateInboxItemFromJobCommand request, CancellationToken cancellationToken)
        {
            return await _inboxRepository.CreateInboxItemFromJobs(request);
        }
    }
}