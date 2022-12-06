using CatsGrpcMicroservice.Entities;
using CatsGrpcMicroservice.Repositories;
using MediatR;

namespace CatsGrpcMicroservice.Commands
{
    public record DeleteCatsCommand : IRequest<double>
    {
        public int InboxItemId { get; set; }
        public string EntryDate { get; set; }
    }
    public class DeleteCatsCommandHandler : IRequestHandler<DeleteCatsCommand, double>
    {
        private readonly ICatsGrpcRepository _catsGrpcRepository;

        public DeleteCatsCommandHandler(ICatsGrpcRepository catsGrpcRepository)
        {
            _catsGrpcRepository = catsGrpcRepository ?? throw new ArgumentNullException(nameof(catsGrpcRepository));
        }

        public async Task<double> Handle(DeleteCatsCommand request, CancellationToken cancellationToken)
        {
            return await _catsGrpcRepository.DeleteCats(request);
        }
    }
}
