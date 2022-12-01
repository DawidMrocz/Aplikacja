using CatsGrpcMicroservice.Commands;
using CatsGrpcMicroservice.Entities;
using Microsoft.Extensions.Caching.Distributed;

namespace CatsGrpcMicroservice.Repositories
{
    public interface ICatsGrpcRepository
    {
        public Task<double> CreateCats(CreateCatsCommand command);
        public Task<double> UpdateCats(UpdateCatsCommand command);
        public Task<double> DeleteCats(DeleteCatsCommand command);



        public Task<Employee> CreateEmployee(CreateEmployeeCommand command);
        public Task<bool> DeleteEmployee(DeleteEmployeeCommand command);
        public Task<Employee> UpdateEmployee(UpdateEmployeeCommand command);
    }
}
