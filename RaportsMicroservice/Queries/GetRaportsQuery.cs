using MediatR;
using RaportsMicroservice.Entities;
using RaportsMicroservice.Repositories;

namespace RaportsMicroservice.Queries
{
    public record GetRaportsQuery : IRequest<List<Raport>>{}
    public class GetRaportsQueryHandler : IRequestHandler<GetRaportsQuery, List<Raport>>
    {
        private readonly IRaportRepository _raportRepository;

        public GetRaportsQueryHandler(IRaportRepository raportRepository)
        {
            _raportRepository = raportRepository ?? throw new ArgumentNullException(nameof(raportRepository));
        }

        public async Task<List<Raport>> Handle(GetRaportsQuery request, CancellationToken cancellationToken)
        {
            return await _raportRepository.GetRaports(request);
        }
    }
}
