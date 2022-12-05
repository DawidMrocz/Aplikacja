using InboxMicroservice.Repositories;
using MediatR;

namespace InboxMicroservice.Commands.FromJobsCommands
{
    public record DeleteInboxItemFromJobCommand : IRequest<bool>
    {
        public int JobId { get; set; }
    }
    public class DeleteInboxItemFromJobCommandHandler : IRequestHandler<DeleteInboxItemFromJobCommand, bool>
    {
        private readonly IInboxRepository _inboxRepository;

        public DeleteInboxItemFromJobCommandHandler(IInboxRepository inboxRepository)
        {
            _inboxRepository = inboxRepository ?? throw new ArgumentNullException(nameof(inboxRepository));
        }

        public async Task<bool> Handle(DeleteInboxItemFromJobCommand request, CancellationToken cancellationToken)
        {
            return await _inboxRepository.DeleteInboxItemFromJobs(request);
        }
    }
}