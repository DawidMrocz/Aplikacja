using InboxMicroservice.Repositories;
using JobMicroservice.Contracts;
using MassTransit;

namespace InboxMicroservice.Consumers
{
    public class DeleteInboxItemConsumer : IConsumer<DeleteInboxItem>
    {
        private readonly IInboxRepository _inboxRepository;
        public DeleteInboxItemConsumer(IInboxRepository inboxRepository)
        {
            _inboxRepository = inboxRepository;
        }
        public async Task Consume(ConsumeContext<DeleteInboxItem> context)
        {
            await _inboxRepository.DeleteInboxItem(new DeleteInboxItem(context.Message.UserId, context.Message.JobId));
        }
    }
}
