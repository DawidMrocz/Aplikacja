using MediatR;
using RaportsMicroservice.Repositories;

namespace RaportsMicroservice.Commands.RaportCommands
{
    public record DeleteRaportCommand : IRequest<bool>
    {
        public int UserId { get; set; }
        public int InboxItemId { get; set; }
    }
    public class DeleteUserRaportRecordCommandHandler : IRequestHandler<DeleteRaportCommand, bool>
    {
        private readonly IRaportRepository _raportRepository;


        public DeleteUserRaportRecordCommandHandler(IRaportRepository raportRepository)
        {
            _raportRepository = raportRepository ?? throw new ArgumentNullException(nameof(raportRepository));
        }

        public async Task<bool> Handle(DeleteRaportCommand request, CancellationToken cancellationToken)
        {
            return await _raportRepository.DeleteRaport(request);
        }
    }
}