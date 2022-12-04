using InboxMicroservice.Commands.InboxItemCommands;
using JobMicroservice.Contracts.InboxItemContracts;
using MassTransit;
using MediatR;

namespace InboxMicroservice.Consumers.InboxItemConsumers
{
    public class DeleteInboxItemConsumer : IConsumer<DeleteInboxItem>
    {
        private readonly IMediator _mediator;
        public DeleteInboxItemConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<DeleteInboxItem> context)
        {
            DeleteInboxItemFromJobCommand deleteInboxItemCommand = new DeleteInboxItemFromJobCommand()
            {
                JobId = context.Message.JobId,
            };
            await _mediator.Send(deleteInboxItemCommand);
        }
    }
}
