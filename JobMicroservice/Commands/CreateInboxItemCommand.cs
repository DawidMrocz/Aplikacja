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

    }
    public class CreateInboxItemCommandHandler : IRequestHandler<CreateInboxItemCommand, bool>
    {
        private readonly IJobRepository _JobRepository;
        private readonly IMapper _mapper;

        public CreateInboxItemCommandHandler(IJobRepository JobRepository, IMapper mapper)
        {
            _JobRepository = JobRepository ?? throw new ArgumentNullException(nameof(JobRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> Handle(CreateInboxItemCommand request, CancellationToken cancellationToken)
        {
            return await _JobRepository.CreateInboxItem(request);
        }
    }
}
