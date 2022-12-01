using InboxMicroservice.Repositories;
using MediatR;

namespace InboxMicroservice.Commands.CatsCommands
{
    public record UpdateDataCommand : IRequest<bool>
    {
        public int InboxItemId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public double Hours { get; set; }
        public string EntryDate { get; set; }
    }
    public class UpdateDataCommandHandler : IRequestHandler<UpdateDataCommand, bool>
    {
        private readonly IInboxRepository _inboxRepository;

        public UpdateDataCommandHandler(IInboxRepository inboxRepository)
        {
            _inboxRepository = inboxRepository ?? throw new ArgumentNullException(nameof(inboxRepository));
        }

        public async Task<bool> Handle(UpdateDataCommand request, CancellationToken cancellationToken)
        {
            return await _inboxRepository.UpdateData(request);
        }
    }
}
