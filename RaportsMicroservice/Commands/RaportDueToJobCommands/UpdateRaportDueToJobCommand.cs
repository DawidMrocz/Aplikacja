using MediatR;
using RaportsMicroservice.Entities;
using RaportsMicroservice.Repositories;

namespace RaportsMicroservice.Commands.RaportDueToJobCommands
{
    public record UpdateRaportDueToJobCommand : IRequest<bool>
    {
        public int JobId { get; set; }
        public string System { get; set; }
        public int Ecm { get; set; }
        public int Gpdm { get; set; }
        public string ProjectNumber { get; set; }
        public string DueDate { get; set; }
        public string Client { get; set; }
    }
    public class UpdateRaportDueToJobCommandHandler : IRequestHandler<UpdateRaportDueToJobCommand, bool>
    {
        private readonly IRaportRepository _raportRepository;


        public UpdateRaportDueToJobCommandHandler(IRaportRepository raportRepository)
        {
            _raportRepository = raportRepository ?? throw new ArgumentNullException(nameof(raportRepository));
        }

        public async Task<bool> Handle(UpdateRaportDueToJobCommand request, CancellationToken cancellationToken)
        {
            return await _raportRepository.UpdateRaportDueToJob(request);
        }
    }
}