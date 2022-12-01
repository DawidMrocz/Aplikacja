using CatsGrpcMicroservice.Entities;
using CatsGrpcMicroservice.Repositories;
using MediatR;

namespace CatsGrpcMicroservice.Commands
{
    public record UpdateEmployeeCommand : IRequest<Employee>
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string CCtr { get; set; }
        public string ActTyp { get; set; }
    }
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Employee>
    {
        private readonly ICatsGrpcRepository _catsGrpcRepository;

        public UpdateEmployeeCommandHandler(ICatsGrpcRepository catsGrpcRepository)
        {
            _catsGrpcRepository = catsGrpcRepository ?? throw new ArgumentNullException(nameof(catsGrpcRepository));
        }

        public async Task<Employee> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await _catsGrpcRepository.UpdateEmployee(request);
        }
    }
}
