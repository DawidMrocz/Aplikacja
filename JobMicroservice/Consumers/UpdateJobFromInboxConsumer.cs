using InboxMicroservice.Contracts.InboxItemContracts;
using JobMicroservice.Commands;
using MassTransit;
using MediatR;

namespace JobMicroservice.Consumers
{
    public class UpdateJobFromInboxConsumer : IConsumer<UpdateJobFromInbox>
    {
        private readonly IMediator _mediator;
        public UpdateJobFromInboxConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<UpdateJobFromInbox> context)
        {
            UpdateJobFromInboxCommand updateJobFromInboxCommand = new UpdateJobFromInboxCommand()
            {
                JobId=context.Message.JobId,
                Status=context.Message.Status,
                WhenComplete = context.Message.WhenComplete,
                Started=context.Message.Started,
                Finished=context.Message.Finished
            };
            await _mediator.Send(updateJobFromInboxCommand);
        }
    }
}
