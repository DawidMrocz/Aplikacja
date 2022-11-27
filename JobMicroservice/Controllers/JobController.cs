using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using JobMicroservice.Commands;
using JobMicroservice.Entities;
using JobMicroservice.Repositories;
using JobMicroservice.Dtos;
using MediatR;
using JobMicroservice.Queries;

namespace JobMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IJobRepository _jobRepository;
        private readonly IMediator _mediatr;

        public ProductController(IJobRepository jobRepository, IMediator mediatr)
        {
            _jobRepository = jobRepository;
            _mediatr = mediatr;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetJobs()
        {
            return Ok(await _mediatr.Send(new GetJobsQuery()));
        }

        [HttpGet("/{id}")]
        [Authorize]
        public async Task<ActionResult<Job>> GetJob([FromRoute] int jobId)
        {
            GetJobQuery getJobQuery = new GetJobQuery()
            {
                JobId = jobId
            };
            return Ok(await _mediatr.Send(getJobQuery));
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Job>> CreateJob([FromBody] CreateJobCommand command)
        {
            return Ok(await _mediatr.Send(command));
        }

        [HttpPut("/{id}")]
        [Authorize]
        public async Task<ActionResult<Job>> UpdateJob([FromRoute] int jobId, [FromBody] UpdateJobDto updateJob)
        {
            UpdateJobCommand updatedJobCommand = new UpdateJobCommand()
            {
                JobId = jobId,
                JobDescription = updateJob.JobDescription,
                Type = updateJob.Type,
                System = updateJob.System,
                Link = updateJob.Link,
                Engineer = updateJob.Engineer,
                 Ecm = updateJob.Ecm,
                Gpdm = updateJob.Gpdm,
                ProjectNumber = updateJob.ProjectNumber,
                Client = updateJob.Client,
                SapText = updateJob.SapText,
                Status = updateJob.Status,
                Received = updateJob.Received,
                DueDate = updateJob.DueDate,
                Started = updateJob.Started,
                Finished = updateJob.Finished    
            };
            return Ok(await _mediatr.Send(updatedJobCommand));
        }

        [HttpDelete("/{id}")]
        [Authorize]
        public async Task<ActionResult<bool>> DeleteJob([FromRoute] int jobId)
        {
            DeleteJobCommand deleteJobCommand = new DeleteJobCommand()
            {
                JobId = jobId
            };
            return Ok(await _mediatr.Send(deleteJobCommand));
        }

        [HttpPost("/{id}/basket")]
        [Authorize]
        public async Task<ActionResult> AddToBasket([FromRoute] int jobId)
        {
            CreateInboxItemCommand createInboxItem = new CreateInboxItemCommand()
            {
                UserId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value),
                JobId = jobId,

            };
            return Ok(await _mediatr.Send(createInboxItem));
        }
    }
}