using MediatR;
using RaportsMicroservice.Repositories;

namespace RaportsMicroservice.Commands.RaportDueToJobCommands
{
    public record DeleteRaportDueToJobCommand : IRequest<bool>
    {
        public int JobId { get; set; }
    }
    public class DeleteUserRaportRecordCommandHandler : IRequestHandler<DeleteRaportDueToJobCommand, bool>
    {
        private readonly IRaportRepository _raportRepository;


        public DeleteUserRaportRecordCommandHandler(IRaportRepository raportRepository)
        {
            _raportRepository = raportRepository ?? throw new ArgumentNullException(nameof(raportRepository));
        }

        public async Task<bool> Handle(DeleteRaportDueToJobCommand request, CancellationToken cancellationToken)
        {
            return await _raportRepository.DeleteRaportDueToJob(request);
        }
    }
}