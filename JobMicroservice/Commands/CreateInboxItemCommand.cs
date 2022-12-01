using AutoMapper;
using JobMicroservice.Entities;
using JobMicroservice.Repositories;
using MediatR;

namespace JobMicroservice.Commands
{
    public record CreateInboxItemCommand : IRequest<bool>
    {
        public int UserId { get; set; }
        public int JobId { get; set; }
        public string Name { get; set; }
    }
    public class CreateInboxItemCommandHandler : IRequestHandler<CreateInboxItemCommand, bool>
    {
        private readonly IJobRepository _jobRepository;

        public CreateInboxItemCommandHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository ?? throw new ArgumentNullException(nameof(jobRepository));
        }

        public async Task<bool> Handle(CreateInboxItemCommand request, CancellationToken cancellationToken)
        {
            return await _jobRepository.CreateInboxItem(request);
        }
    }
}
