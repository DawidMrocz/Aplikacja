using MassTransit.Mediator;
using MediatR;
using RaportMicroservice.Queries;
using RaportsMicroservice.Entities;
using RaportsMicroservice.Repositories;

namespace RaportsMicroservice.Commands.UserRaportRecordCommands
{
    public record AddUserRaportRecordCommand : IRequest<UserRaport>
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public double Hours { get; set; }
        public string SendDate { get; set; }
        public string System { get; set; }
        public int Ecm { get; set; }
        public int Gpdm { get; set; }
        public string ProjectNumber { get; set; }
        public int Components { get; set; }
        public int DrawingOfComponent { get; set; }
        public int DrawingOfAssemblies { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime FinishedDate { get; set; }
        public string Client { get; set; }
    }
    public class AddUserRaportRecordCommandHandler : IRequestHandler<AddUserRaportRecordCommand, UserRaport>
    {
        private readonly IRaportRepository _raportRepository;

        public AddUserRaportRecordCommandHandler(IRaportRepository raportRepository)
        {
            _raportRepository = raportRepository ?? throw new ArgumentNullException(nameof(raportRepository));
        }

        public async Task<UserRaport> Handle(AddUserRaportRecordCommand request, CancellationToken cancellationToken)
        {
            return await _raportRepository.AddUserRaportRecord(request);
        }
    }
}
