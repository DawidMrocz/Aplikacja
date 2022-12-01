using InboxMicroservice.Entities;
using InboxMicroservice.Repositories;
using MediatR;

namespace InboxMicroservice.Commands.CatsCommands
{
    public record CreateDataCommand : IRequest<bool>
    {
        public int InboxItemId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public double Hours { get; set; }
        public string EntryDate { get; set; }
    }
    public class CreateDataCommandHandler : IRequestHandler<CreateDataCommand, bool>
    {
        private readonly IInboxRepository _inboxRepository;

        public CreateDataCommandHandler(IInboxRepository inboxRepository)
        {
            _inboxRepository = inboxRepository ?? throw new ArgumentNullException(nameof(inboxRepository));
        }

        public async Task<bool> Handle(CreateDataCommand request, CancellationToken cancellationToken)
        {
            return await _inboxRepository.CreateData(request);
        }
    }
}
