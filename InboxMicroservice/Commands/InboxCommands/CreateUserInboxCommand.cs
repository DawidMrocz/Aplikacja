using InboxMicroservice.Entities;
using InboxMicroservice.Repositories;
using MediatR;

namespace InboxMicroservice.Commands.InboxCommands
{
    public record CreateUserInboxCommand : IRequest<Inbox>
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string CCtr { get; set; }
        public string ActTyp { get; set; }
    }
    public class CreateUserInboxCommandHandler : IRequestHandler<CreateUserInboxCommand, Inbox>
    {
        private readonly IInboxRepository _inboxRepository;

        public CreateUserInboxCommandHandler(IInboxRepository inboxRepository)
        {
            _inboxRepository = inboxRepository ?? throw new ArgumentNullException(nameof(inboxRepository));
        }

        public async Task<Inbox> Handle(CreateUserInboxCommand request, CancellationToken cancellationToken)
        {
            return await _inboxRepository.CreateUserInbox(request);
        }
    }
}
