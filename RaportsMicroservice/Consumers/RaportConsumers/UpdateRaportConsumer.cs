﻿using InboxMicroservice.Contracts.RaportContracts;
using MassTransit;
using MediatR;
using RaportsMicroservice.Commands.RaportCommands;

namespace RaportsMicroservice.Consumers.RaportConsumers
{
    public class UpdateRaportConsumer : IConsumer<UpdateRaport>
    {
        private readonly IMediator _mediator;
        public UpdateRaportConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<UpdateRaport> context)
        {
            UpdateRaportCommand updateRaportCommand = new UpdateRaportCommand()
            {
                UserId = context.Message.UserId,
                Name = context.Message.Name,
                InboxItemId = context.Message.InboxItemId,
                Hours = context.Message.hours,
                DueDate = context.Message.DueDate,
                StartedDate = context.Message.Started,
                FinishedDate = context.Message.Finished,
                System = context.Message.System,
                Ecm = context.Message.Ecm,
                Gpdm = context.Message.Gpdm,
                ProjectNumber = context.Message.ProjectNumber,
                Components = context.Message.Components,
                DrawingOfAssemblies = context.Message.DrawingsAssembly,
                DrawingOfComponent = context.Message.DrawingsComponents,
                Client = context.Message.Client
            };
            await _mediator.Send(updateRaportCommand);
        }
    }
}
