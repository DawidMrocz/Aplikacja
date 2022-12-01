using CatsGrpcMicroservice.Entities;
using CatsGrpcMicroservice.Repositories;
using MediatR;

namespace CatsGrpcMicroservice.Commands
{
    public record DeleteEmployeeCommand : IRequest<bool>
    {
        public int UserId { get; set; }
    }
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly ICatsGrpcRepository _catsGrpcRepository;

        public DeleteEmployeeCommandHandler(ICatsGrpcRepository catsGrpcRepository)
        {
            _catsGrpcRepository = catsGrpcRepository ?? throw new ArgumentNullException(nameof(catsGrpcRepository));
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await _catsGrpcRepository.DeleteEmployee(request);
        }
    }
}
