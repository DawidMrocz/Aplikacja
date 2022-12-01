using InboxMicroservice.Commands.InboxCommands;
using MassTransit;
using MediatR;
using UserMicroservice.Contracts.InboxContracts;

namespace InboxMicroservice.Consumers.InboxConsumers
{
    public class DeleteUserInboxConsumer : IConsumer<DeleteUserInbox>
    {
        private readonly IMediator _mediator;
        public DeleteUserInboxConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<DeleteUserInbox> context)
        {
            DeleteUserInboxCommand deleteUserInboxCommand = new DeleteUserInboxCommand()
            {
                UserId= context.Message.UserId
            };
            await _mediator.Send(deleteUserInboxCommand);
        }
    }
}
