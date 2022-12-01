using JobMicroservice.Entities;
using JobMicroservice.Repositories;
using MediatR;

namespace JobMicroservice.Commands
{
    public class UpdateJobFromInboxCommand : IRequest<Job>
    {
        public int JobId { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
        public string? Started { get; set; }
        public string? Finished { get; set; }
        public string? WhenComplete { get; set; }
    }
    public class UpdateJobFromInboxCommandHandler : IRequestHandler<UpdateJobFromInboxCommand, Job>
    {
        private readonly IJobRepository _jobRepository;

        public UpdateJobFromInboxCommandHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository ?? throw new ArgumentNullException(nameof(jobRepository));
        }

        public async Task<Job> Handle(UpdateJobFromInboxCommand request, CancellationToken cancellationToken)
        {
            return await _jobRepository.UpdateJobFromInbox(request);
        }
    }
}
