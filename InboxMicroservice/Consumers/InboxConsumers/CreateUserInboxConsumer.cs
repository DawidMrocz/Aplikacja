using InboxMicroservice.Commands.InboxCommands;
using InboxMicroservice.Repositories;
using MassTransit;
using MediatR;
using UserMicroservice.Contracts.InboxContracts;

namespace InboxMicroservice.Consumers.InboxConsumers
{
    public class CreateUserInboxConsumer : IConsumer<CreateUserInbox>
    {
        private readonly IMediator _mediator;
        public CreateUserInboxConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<CreateUserInbox> context)
        {
            CreateUserInboxCommand createUserInboxCommand = new CreateUserInboxCommand()
            {
                UserId= context.Message.UserId,
                Name= context.Message.Name,
                Photo= context.Message.Photo,
                CCtr = context.Message.CCtr,
                ActTyp = context.Message.ActTyp
            };
            await _mediator.Send(createUserInboxCommand);
        }
    }
}
