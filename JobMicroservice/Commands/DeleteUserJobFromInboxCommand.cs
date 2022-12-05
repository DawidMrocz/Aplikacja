using JobMicroservice.Repositories;
using MediatR;

namespace JobMicroservice.Commands
{
    public record DeleteUserJobFromInboxCommand : IRequest<bool>
    {
        public int JobId { get; set; }
        public int UserId { get; set; }
    }
    public class DeleteUserJobFromInboxCommandHandler : IRequestHandler<DeleteUserJobFromInboxCommand, bool>
    {
        private readonly IJobRepository _jobRepository;

        public DeleteUserJobFromInboxCommandHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository ?? throw new ArgumentNullException(nameof(jobRepository));
        }

        public async Task<bool> Handle(DeleteUserJobFromInboxCommand request, CancellationToken cancellationToken)
        {
            await _jobRepository.DeleteUserJobFormInbox(request);
            return true;
        }
    }
}
