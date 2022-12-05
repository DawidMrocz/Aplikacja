using InboxMicroservice.Contracts.InboxItemContracts;
using JobMicroservice.Commands;
using MassTransit;
using MediatR;

namespace JobMicroservice.Consumers
{
    public class DeleteUserJobFromInboxConsumer : IConsumer<DeleteUserJobFromInbox>
    {
        private readonly IMediator _mediator;
        public DeleteUserJobFromInboxConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<DeleteUserJobFromInbox> context)
        {
            Console.WriteLine(context.Message.JobId);
            Console.WriteLine(context.Message.UserId);
            DeleteUserJobFromInboxCommand deleteJobFromInboxCommand = new DeleteUserJobFromInboxCommand()
            {
                JobId = context.Message.JobId,
                UserId = context.Message.UserId
            };
            await _mediator.Send(deleteJobFromInboxCommand);
        }
    }
}
