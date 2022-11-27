using JobMicroservice.Entities;
using JobMicroservice.Repositories;
using MediatR;

namespace JobMicroservice.Queries
{
    public record GetJobQuery : IRequest<Job>
    {
        public int JobId { get; set; }
    }
    public class GetJobQueryHandler : IRequestHandler<GetJobQuery, Job>
    {
        private readonly IJobRepository _jobRepository;

        public GetJobQueryHandler(IJobRepository userRepository)
        {
            _jobRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<Job> Handle(GetJobQuery request, CancellationToken cancellationToken)
        {
            return await _jobRepository.GetJob(request);
        }
    }
}
