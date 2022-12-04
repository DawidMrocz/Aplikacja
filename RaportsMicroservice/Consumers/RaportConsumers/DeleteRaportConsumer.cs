using InboxMicroservice.Contracts.RaportContracts;
using MassTransit;
using MediatR;
using RaportsMicroservice.Commands.RaportCommands;

namespace RaportsMicroservice.Consumers.RaportConsumers
{
    public class DeleteRaportConsumer : IConsumer<DeleteRaport>
    {
        private readonly IMediator _mediator;
        public DeleteRaportConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<DeleteRaport> context)
        {
            DeleteRaportCommand deleteRaportCommand = new DeleteRaportCommand()
            {
                InboxItemId = context.Message.InboxItemId
            };
            await _mediator.Send(deleteRaportCommand);
        }
    }
}
