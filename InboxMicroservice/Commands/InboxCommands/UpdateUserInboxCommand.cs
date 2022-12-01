using InboxMicroservice.Entities;
using InboxMicroservice.Repositories;
using MediatR;

namespace InboxMicroservice.Commands.InboxCommands
{
    public record UpdateUserInboxCommand : IRequest<Inbox>
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string CCtr { get; set; }
        public string ActTyp { get; set; }
    }
    public class UpdateUserInboxCommandHandler : IRequestHandler<UpdateUserInboxCommand, Inbox>
    {
        private readonly IInboxRepository _inboxRepository;

        public UpdateUserInboxCommandHandler(IInboxRepository inboxRepository)
        {
            _inboxRepository = inboxRepository ?? throw new ArgumentNullException(nameof(inboxRepository));
        }

        public async Task<Inbox> Handle(UpdateUserInboxCommand request, CancellationToken cancellationToken)
        {
            return await _inboxRepository.UpdateUserInbox(request);
        }
    }
}