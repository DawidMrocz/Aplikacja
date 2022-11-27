using InboxMicroservice.Repositories;
using MassTransit;
using UserMicroservice.Contracts;

namespace InboxMicroservice.Consumers
{
    public class DeleteUserInboxConsumer : IConsumer<DeleteUserInbox>
    {
        private readonly IInboxRepository _inboxRepository;
        public DeleteUserInboxConsumer(IInboxRepository inboxRepository)
        {
            _inboxRepository = inboxRepository;
        }
        public async Task Consume(ConsumeContext<DeleteUserInbox> context)
        {
            await _inboxRepository.DeleteUserInbox(new DeleteUserInbox(context.Message.UserId));
        }
    }
}
