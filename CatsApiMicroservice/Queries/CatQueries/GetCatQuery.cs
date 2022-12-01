using CatsApiMicroservice.Entities;
using CatsApiMicroservice.Repositories;
using MediatR;

namespace CatsApiMicroservice.Queries.CatQueries
{
    public record GetCatQuery : IRequest<Cat>
    {
        public int UserId { get; set; }
        public int CatId { get; set; }
    }
    public class GetCatsQueryHandler : IRequestHandler<GetCatQuery, Cat>
    {
        private readonly IUserCatsRepository _userCatsRepository;

        public GetCatsQueryHandler(IUserCatsRepository userRepository)
        {
            _userCatsRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<Cat> Handle(GetCatQuery request, CancellationToken cancellationToken)
        {
            return await _userCatsRepository.GetCat(request);
        }
    }
}