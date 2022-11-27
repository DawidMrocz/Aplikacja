using InboxMicroservice.Repositories;
using JobMicroservice.Contracts;
using MassTransit;

namespace InboxMicroservice.Consumers
{
    public class CreateInboxItemConsumer : IConsumer<CreateInboxItem>
    {
        private readonly IInboxRepository _inboxRepository;
        public CreateInboxItemConsumer(IInboxRepository inboxRepository)
        {
            _inboxRepository = inboxRepository;
        }
        public async Task Consume(ConsumeContext<CreateInboxItem> context)
        {
            CreateInboxItem item = new 
            (
                context.Message.UserId,
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
            await _inboxRepository.CreateInboxItem(item);
        }
    }
}
