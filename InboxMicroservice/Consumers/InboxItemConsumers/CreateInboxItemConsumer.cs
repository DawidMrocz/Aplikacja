using InboxMicroservice.Commands.InboxItemCommands;
using JobMicroservice.Contracts.InboxItemContracts;
using MassTransit;
using MediatR;

namespace InboxMicroservice.Consumers.InboxItemConumers
{
    public class CreateInboxItemConsumer : IConsumer<CreateInboxItem>
    {
        private readonly IMediator _mediator;
        public CreateInboxItemConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<CreateInboxItem> context)
        {
            CreateInboxItemFromJobCommand createInboxItemCommand = new CreateInboxItemFromJobCommand()
            {
                UserId = context.Message.UserId,
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
            await _mediator.Send(createInboxItemCommand);
        }
    }
}
