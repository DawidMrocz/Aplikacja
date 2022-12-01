using CatsGrpcMicroservice.Entities;
using CatsGrpcMicroservice.Repositories;
using MediatR;

namespace CatsGrpcMicroservice.Commands
{
    public record CreateEmployeeCommand : IRequest<Employee>
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string CCtr { get; set; }
        public string ActTyp { get; set; }
    }
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Employee>
    {
        private readonly ICatsGrpcRepository _catsGrpcRepository;

        public CreateEmployeeCommandHandler(ICatsGrpcRepository catsGrpcRepository)
        {
            _catsGrpcRepository = catsGrpcRepository ?? throw new ArgumentNullException(nameof(catsGrpcRepository));
        }

        public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await _catsGrpcRepository.CreateEmployee(request);
        }
    }
}
