﻿using AutoMapper;
using MediatR;
using JobMicroservice.Repositories;
using JobMicroservice.Entities;

namespace JobMicroservice.Commands
{
    public record CreateJobCommand : IRequest<Job>
    {
        public string JobDescription { get; set; }
        public string Type { get; set; }
        public string System { get; set; }
        public string Link { get; set; }
        public string Engineer { get; set; }
        public int Ecm { get; set; }
        public int Gpdm { get; set; }
        public string ProjectNumber { get; set; }
        public string Client { get; set; }
        public string SapText { get; set; }
        public string Status { get; set; }
        public DateTime Received { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? Started { get; set; }
        public DateTime? Finished { get; set; }
    }
    public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, Job>
    {
        private readonly IJobRepository _JobRepository;
        private readonly IMapper _mapper;

        public CreateJobCommandHandler(IJobRepository JobRepository, IMapper mapper)
        {
            _JobRepository = JobRepository ?? throw new ArgumentNullException(nameof(JobRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Job> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            return await _JobRepository.CreateJob(request);
        }
    }
}
