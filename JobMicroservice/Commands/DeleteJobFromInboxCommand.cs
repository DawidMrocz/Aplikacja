using JobMicroservice.Repositories;
using MediatR;

namespace JobMicroservice.Commands
{
    public record DeleteJobFromInboxCommand : IRequest<bool>
    {
        public int JobId { get; set; }
        public int UserId { get; set; }
    }
    public class DeleteJobFromInboxCommandHandler : IRequestHandler<DeleteJobFromInboxCommand, bool>
    {
        private readonly IJobRepository _jobRepository;

        public DeleteJobFromInboxCommandHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository ?? throw new ArgumentNullException(nameof(jobRepository));
        }

        public async Task<bool> Handle(DeleteJobFromInboxCommand request, CancellationToken cancellationToken)
        {
            await _jobRepository.DeleteUserJobFormInbox(request);
            return true;
        }
    }
}
