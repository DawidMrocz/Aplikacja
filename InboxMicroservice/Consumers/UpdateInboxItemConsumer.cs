using InboxMicroservice.Repositories;
using JobMicroservice.Contracts;
using MassTransit;

namespace InboxMicroservice.Consumers
{
    public class UpdateInboxItemConsumer : IConsumer<UpdateInboxItem>
    {
        private readonly IInboxRepository _inboxRepository;
        public UpdateInboxItemConsumer(IInboxRepository inboxRepository)
        {
            _inboxRepository = inboxRepository;
        }
        public async Task Consume(ConsumeContext<UpdateInboxItem> context)
        {
            UpdateInboxItem item = new (
                context.Message.JobId,
                context.Message.JobDescription,
                context.Message.Type,
                context.Message.System,
                context.Message.Link,
                context.Message.Engineer,
                context.Message.Ecm,
                context.Message.Gpdm,
                context.Message.ProjectNumber,
                context.Message.Client,
                context.Message.SapText,
                context.Message.Status
             );
            await _inboxRepository.UpdateInboxItem(item);
        }
    }
}
