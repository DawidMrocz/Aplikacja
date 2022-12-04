using MediatR;
using RaportsMicroservice.Entities;
using RaportsMicroservice.Repositories;

namespace RaportsMicroservice.Commands.RaportCommands
{
    public record UpdateRaportCommand : IRequest<UserRaportRecord>
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int InboxItemId { get; set; }
        public int JobId { get; set; }
        public double Hours { get; set; }
        public string System { get; set; }
        public int Ecm { get; set; }
        public int Gpdm { get; set; }
        public string ProjectNumber { get; set; }
        public int Components { get; set; }
        public int DrawingOfComponent { get; set; }
        public int DrawingOfAssemblies { get; set; }
        public string DueDate { get; set; }
        public string StartedDate { get; set; }
        public string FinishedDate { get; set; }
        public string Client { get; set; }
    }
    public class UpdateUserRaportRecordCommandHandler : IRequestHandler<UpdateRaportCommand, UserRaportRecord>
    {
        private readonly IRaportRepository _raportRepository;


        public UpdateUserRaportRecordCommandHandler(IRaportRepository raportRepository)
        {
            _raportRepository = raportRepository ?? throw new ArgumentNullException(nameof(raportRepository));
        }

        public async Task<UserRaportRecord> Handle(UpdateRaportCommand request, CancellationToken cancellationToken)
        {
            return await _raportRepository.UpdateRaport(request);
        }
    }
}