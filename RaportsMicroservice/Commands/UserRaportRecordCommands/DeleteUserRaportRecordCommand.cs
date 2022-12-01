using MediatR;
using RaportsMicroservice.Entities;
using RaportsMicroservice.Repositories;

namespace RaportsMicroservice.Commands.UserRaportRecordCommands
{
    public record DeleteUserRaportRecordCommand : IRequest<bool>
    {
        public int UserRaportRecordId { get; set; }
    }
    public class DeleteUserRaportRecordCommandHandler : IRequestHandler<DeleteUserRaportRecordCommand, bool>
    {
        private readonly IRaportRepository _raportRepository;


        public DeleteUserRaportRecordCommandHandler(IRaportRepository raportRepository)
        {
            _raportRepository = raportRepository ?? throw new ArgumentNullException(nameof(raportRepository));
        }

        public async Task<bool> Handle(DeleteUserRaportRecordCommand request, CancellationToken cancellationToken)
        {
            return await _raportRepository.DeleteUserRaportRecord(request);
        }
    }
}