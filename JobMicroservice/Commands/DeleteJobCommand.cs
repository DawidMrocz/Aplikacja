using MediatR;
using JobMicroservice.Repositories;

namespace JobMicroservice.Commands
{
    public record DeleteJobCommand : IRequest<bool>
    {
        public int JobId { get; set; }
    }
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteJobCommand, bool>
    {
        private readonly IJobRepository _jobRepository;

        public DeleteTaskCommandHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository ?? throw new ArgumentNullException(nameof(jobRepository));
        }

        public async Task<bool> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
        {
            await _jobRepository.DeleteJob(request);
            return true;
        }
    }
}
