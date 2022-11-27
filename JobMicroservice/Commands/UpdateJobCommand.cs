﻿using AutoMapper;
using JobMicroservice.Entities;
using JobMicroservice.Repositories;
using MediatR;

namespace JobMicroservice.Commands
{
    public class UpdateJobCommand : IRequest<Job>
    {
        public int JobId { get; set; }
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
    public class UpdateJobCommandHandler : IRequestHandler<UpdateJobCommand, Job>
    {
        private readonly IJobRepository _jobRepository;

        public UpdateJobCommandHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository ?? throw new ArgumentNullException(nameof(jobRepository));
        }

        public async Task<Job> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
        {
            return await _jobRepository.UpdateJob(request);
        }
    }
}
