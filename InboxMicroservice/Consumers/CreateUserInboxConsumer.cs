using InboxMicroservice.Repositories;
using MassTransit;
using UserMicroservice.Contracts;

namespace InboxMicroservice.Consumers
{
    public class CreateUserInboxConsumer : IConsumer<CreateUserInbox>
    {
        private readonly IInboxRepository _InboxRepository;
        public CreateUserInboxConsumer(IInboxRepository InboxRepository)
        {
            _InboxRepository = InboxRepository;
        }
        public async Task Consume(ConsumeContext<CreateUserInbox> context)
        {
            await _InboxRepository.CreateUserInbox(new CreateUserInbox(context.Message.UserId, context.Message.Name, context.Message.Photo));
        }
    }
}
