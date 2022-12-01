using InboxMicroservice.Commands.InboxItemCommands;
using JobMicroservice.Contracts.InboxItemContracts;
using MassTransit;
using MediatR;

namespace InboxMicroservice.Consumers.InboxItemConumers
{
    public class UpdateInboxItemConsumer : IConsumer<UpdateInboxItem>
    {
        private readonly IMediator _mediator;
        public UpdateInboxItemConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<UpdateInboxItem> context)
        {
            UpdateInboxItemCommand updateInboxItemCommand = new UpdateInboxItemCommand()
            {
                JobId = context.Message.JobId,
                JobDescription = context.Message.JobDescription,
                Type = context.Message.Type,
                System = context.Message.System,
                Link = context.Message.Link,
                Engineer = context.Message.Engineer,
                Ecm = context.Message.Ecm,
                Gpdm = context.Message.Gpdm,
                ProjectNumber = context.Message.ProjectNumber,
                Client = context.Message.Client,
                ProjectName = context.Message.ProjectName,
                Status = context.Message.Status,
                Received = context.Message.Received,
                DueDate = context.Message.DueDate,
            };
            await _mediator.Send(updateInboxItemCommand);
        }
    }
}
