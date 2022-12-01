using InboxMicroservice.Contracts.UserRaportRecordContracts;
using MassTransit;
using MediatR;
using RaportsMicroservice.Commands.UserRaportRecordCommands;

namespace RaportsMicroservice.Consumers
{
    public class AddUserRaportRecordConsumer : IConsumer<AddUserRaportRecord>
    {
        private readonly IMediator _mediator;
        public AddUserRaportRecordConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<AddUserRaportRecord> context)
        {
            AddUserRaportRecordCommand addUserRaportRecordCommand = new AddUserRaportRecordCommand()
            {
                UserId = context.Message.UserId,
                Name = context.Message.Name,
                Hours = context.Message.Hours,
                SendDate = context.Message.SendDate,
                System = context.Message.System,
                Ecm = context.Message.Ecm,
                Gpdm = context.Message.Gpdm,
                ProjectNumber = context.Message.ProjectNumber,
                Components = context.Message.Components,
                DrawingOfComponent = context.Message.DrawingOfComponent,
                DrawingOfAssemblies = context.Message.DrawingOfAssemblies,
                DueDate = context.Message.DueDate,
                StartedDate = context.Message.StartedDate,
                FinishedDate = context.Message.FinishedDate,
                Client = context.Message.Client,
            };
            await _mediator.Send(addUserRaportRecordCommand);
        }
    }
}
