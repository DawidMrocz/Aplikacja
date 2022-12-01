using MediatR;
using CatsGrpcMicroservice.Repositories;
using CatsGrpcMicroservice.Entities;

namespace CatsGrpcMicroservice.Commands
{
    public record CreateCatsCommand : IRequest<double>
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string CatCreated { get; set; }
        public int InboxItemId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectNumber { get; set; }
        public string Client { get; set; }
        public double Hours { get; set; }
        public string EntryDate { get; set; }
    }
    public class AddUserCatsRecordHoursCommandHandler : IRequestHandler<CreateCatsCommand, double>
    {
        private readonly ICatsGrpcRepository _catsGrpcRepository;

        public AddUserCatsRecordHoursCommandHandler(ICatsGrpcRepository catsGrpcRepository)
        {
            _catsGrpcRepository = catsGrpcRepository ?? throw new ArgumentNullException(nameof(catsGrpcRepository));
        }

        public async Task<double> Handle(CreateCatsCommand request, CancellationToken cancellationToken)
        {
            return await _catsGrpcRepository.CreateCats(request);
        }
    }
}
