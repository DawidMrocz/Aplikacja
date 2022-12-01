using InboxMicroservice.Commands.InboxCommands;
using MassTransit;
using MediatR;
using UserMicroservice.Contracts.InboxContracts;

namespace InboxMicroservice.Consumers.InboxConsumers
{
    public class UpdateUserInboxConsumer : IConsumer<UpdateUserInbox>
    {
        private readonly IMediator _mediator;
        public UpdateUserInboxConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<UpdateUserInbox> context)
        {
            UpdateUserInboxCommand updateUserInboxCommand = new UpdateUserInboxCommand()
            {
                UserId = context.Message.UserId,
                Name = context.Message.Name,
                Photo = context.Message.Photo,
                CCtr = context.Message.CCtr,
                ActTyp = context.Message.ActTyp
            };
            await _mediator.Send(updateUserInboxCommand);
        }
    }
}
