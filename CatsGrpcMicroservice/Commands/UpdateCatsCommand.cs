using CatsGrpcMicroservice.Entities;
using CatsGrpcMicroservice.Repositories;
using MediatR;

namespace CatsGrpcMicroservice.Commands
{
    public record UpdateCatsCommand : IRequest<double>
    {
        public int UserId { get; set; }
        public int InboxItemId { get; set; }
        public double Hours { get; set; }
        public string EntryDate { get; set; }
    }
    public class UpdateCatsCommandHandler : IRequestHandler<UpdateCatsCommand, double>
    {
        private readonly ICatsGrpcRepository _catsGrpcRepository;

        public UpdateCatsCommandHandler(ICatsGrpcRepository catsGrpcRepository)
        {
            _catsGrpcRepository = catsGrpcRepository ?? throw new ArgumentNullException(nameof(catsGrpcRepository));
        }

        public async Task<double> Handle(UpdateCatsCommand request, CancellationToken cancellationToken)
        {
            return await _catsGrpcRepository.UpdateCats(request);
        }
    }
}
