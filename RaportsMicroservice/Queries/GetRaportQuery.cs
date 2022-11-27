using MediatR;
using RaportsMicroservice.Entities;
using RaportsMicroservice.Repositories;

namespace RaportMicroservice.Queries
{
    public record GetRaportQuery : IRequest<Raport>
    {
        public int RaportId { get; set; }
    }
    public class GetRaportQueryHandler : IRequestHandler<GetRaportQuery, Raport>
    {
        private readonly IRaportRepository _raportRepository;

        public GetRaportQueryHandler(IRaportRepository raportRepository)
        {
            _raportRepository = raportRepository ?? throw new ArgumentNullException(nameof(raportRepository));
        }

        public async Task<Raport> Handle(GetRaportQuery request, CancellationToken cancellationToken)
        {
            return await _raportRepository.GetRaport(request);
        }
    }
}
