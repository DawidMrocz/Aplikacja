using CatsApiMicroservice.Entities;
using CatsApiMicroservice.Repositories;
using MediatR;

namespace CatsApiMicroservice.Queries.EmployeeQueries
{
    public record GetEmployeeQuery : IRequest<Employee>
    {
        public int UserId { get; set; }
    }
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, Employee>
    {
        private readonly IUserCatsRepository _userCatsRepository;

        public GetEmployeeQueryHandler(IUserCatsRepository userRepository)
        {
            _userCatsRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<Employee> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            return await _userCatsRepository.GetEmployee(request);
        }
    }
}
