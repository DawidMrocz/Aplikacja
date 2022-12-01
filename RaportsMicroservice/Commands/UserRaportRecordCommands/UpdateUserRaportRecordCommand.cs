using MediatR;
using RaportsMicroservice.Entities;
using RaportsMicroservice.Repositories;

namespace RaportsMicroservice.Commands.UserRaportRecordCommands
{
    public record UpdateUserRaportRecordCommand : IRequest<UserRaportRecord>
    {
        public int UserRecordId { get; set; }
        public int UserId { get; set; }
        public int RaportId { get; set; }
        public double TaskHours { get; set; }
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
    public class UpdateUserRaportRecordCommandHandler : IRequestHandler<UpdateUserRaportRecordCommand, UserRaportRecord>
    {
        private readonly IRaportRepository _raportRepository;


        public UpdateUserRaportRecordCommandHandler(IRaportRepository raportRepository)
        {
            _raportRepository = raportRepository ?? throw new ArgumentNullException(nameof(raportRepository));
        }

        public async Task<UserRaportRecord> Handle(UpdateUserRaportRecordCommand request, CancellationToken cancellationToken)
        {
            return await _raportRepository.UpdateUserRaportRecord(request);
        }
    }
}