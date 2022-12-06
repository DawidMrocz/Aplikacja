using InboxMicroservice.Repositories;
using MediatR;

namespace InboxMicroservice.Commands.CatsCommands
{
    public record DeleteDataCommand : IRequest<double>
    {
        public int UserId { get; set; }
        public int InboxItemId { get; set; }
        public string EntryData { get; set; }
    }
    public class DeleteDataCommandHandler : IRequestHandler<DeleteDataCommand, double>
    {
        private readonly IInboxRepository _inboxRepository;

        public DeleteDataCommandHandler(IInboxRepository inboxRepository)
        {
            _inboxRepository = inboxRepository ?? throw new ArgumentNullException(nameof(inboxRepository));
        }

        public async Task<double> Handle(DeleteDataCommand request, CancellationToken cancellationToken)
        {
            return await _inboxRepository.DeleteData(request);
        }
    }
}
