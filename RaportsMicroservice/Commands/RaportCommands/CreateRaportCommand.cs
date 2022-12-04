using MediatR;
using RaportsMicroservice.Entities;
using RaportsMicroservice.Repositories;

namespace RaportsMicroservice.Commands.RaportCommands
{
    public record CreateRaportCommand : IRequest<UserRaport>
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
    public class AddUserRaportRecordCommandHandler : IRequestHandler<CreateRaportCommand, UserRaport>
    {
        private readonly IRaportRepository _raportRepository;

        public AddUserRaportRecordCommandHandler(IRaportRepository raportRepository)
        {
            _raportRepository = raportRepository ?? throw new ArgumentNullException(nameof(raportRepository));
        }

        public async Task<UserRaport> Handle(CreateRaportCommand request, CancellationToken cancellationToken)
        {
            return await _raportRepository.CreateRaport(request);
        }
    }
}
