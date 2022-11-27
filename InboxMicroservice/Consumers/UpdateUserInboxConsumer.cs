using InboxMicroservice.Repositories;
using MassTransit;
using UserMicroservice.Contracts;

namespace InboxMicroservice.Consumers
{
    public class UpdateUserInboxConsumer : IConsumer<UpdateUserInbox>
    {
        private readonly IInboxRepository _inboxRepository;
        public UpdateUserInboxConsumer(IInboxRepository inboxRepository)
        {
            _inboxRepository = inboxRepository;
        }
        public async Task Consume(ConsumeContext<UpdateUserInbox> context)
        {
            await _inboxRepository.UpdateUserInbox(new UpdateUserInbox(context.Message.UserId, context.Message.Name, context.Message.Photo));
        }
    }
}
