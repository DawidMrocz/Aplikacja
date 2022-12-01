using InboxMicroservice.Entities;
using InboxMicroservice.Repositories;
using MediatR;

namespace InboxMicroservice.Queries
{
    public record GetMyInboxQuery : IRequest<Inbox>
    {
        public int UserId { get; set; }
    }
    public class GetMyInboxQueryHandler : IRequestHandler<GetMyInboxQuery, Inbox>
    {
        private readonly IInboxRepository _inboxRepository;

        public GetMyInboxQueryHandler(IInboxRepository inboxRepository)
        {
            _inboxRepository = inboxRepository ?? throw new ArgumentNullException(nameof(inboxRepository));
        }

        public async Task<Inbox> Handle(GetMyInboxQuery request, CancellationToken cancellationToken)
        {
            return await _inboxRepository.GetMyInbox(request);
        }
    }
}
