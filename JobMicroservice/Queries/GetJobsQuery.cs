using JobMicroservice.Entities;
using JobMicroservice.Repositories;
using MediatR;

namespace JobMicroservice.Queries
{
    public record GetJobsQuery : IRequest<List<Job>>
    {
        public int JobId { get; set; }
    }
    public class GetJobsQueryHandler : IRequestHandler<GetJobsQuery, List<Job>>
    {
        private readonly IJobRepository _jobRepository;

        public GetJobsQueryHandler(IJobRepository userRepository)
        {
            _jobRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<List<Job>> Handle(GetJobsQuery request, CancellationToken cancellationToken)
        {
            return await _jobRepository.GetJobs();
        }
    }
}
