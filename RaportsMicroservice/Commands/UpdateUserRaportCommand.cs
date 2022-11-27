using MediatR;
using RaportsMicroservice.Entities;
using RaportsMicroservice.Repositories;

namespace RaportsMicroservice.Commands
{
    public record UpdateUserRaportCommand : IRequest<UserRaport>
    {
        public int UserRaportId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public int UserHours { get; set; }
    }
    public class UpdateUserRaportCommandHandler : IRequestHandler<UpdateUserRaportCommand, UserRaport>
    {
        private readonly IRaportRepository _raportRepository;


        public UpdateUserRaportCommandHandler(IRaportRepository raportRepository)
        {
            _raportRepository = raportRepository ?? throw new ArgumentNullException(nameof(raportRepository));
        }

        public async Task<UserRaport> Handle(UpdateUserRaportCommand request, CancellationToken cancellationToken)
        {
            return await _raportRepository.UpdateUserRaport(request);
        }
    }
}