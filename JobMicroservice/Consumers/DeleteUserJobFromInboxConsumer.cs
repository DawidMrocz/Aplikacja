using InboxMicroservice.Contracts.InboxItemContracts;
using JobMicroservice.Commands;
using MassTransit;
using MediatR;

namespace JobMicroservice.Consumers
{
    public class DeleteUserJobFromInboxConsumer : IConsumer<DeleteInboxItemFromInbox>
    {
        private readonly IMediator _mediator;
        public DeleteUserJobFromInboxConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<DeleteInboxItemFromInbox> context)
        {
            DeleteJobFromInboxCommand deleteJobFromInboxCommand = new DeleteJobFromInboxCommand()
            {
                JobId = context.Message.JobId,
                UserId = context.Message.UserId
            };
            await _mediator.Send(deleteJobFromInboxCommand);
        }
    }
}
