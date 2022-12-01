using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using JobMicroservice.Commands;
using JobMicroservice.Entities;
using JobMicroservice.Dtos;
using MediatR;
using JobMicroservice.Queries;

namespace JobMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public ProductController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet("/Products")]
        [Authorize]
        public async Task<ActionResult> GetJobs()
        {
            return Ok(await _mediatr.Send(new GetJobsQuery()));
        }

        [HttpGet("/Product/{jobId}")]
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

        [HttpPut("/UpdateProduct/{jobId}")]
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
                ProjectName = updateJob.ProjectName,
                Client = updateJob.Client,
                Received = updateJob.Received,
                DueDate = updateJob.DueDate,  
            };
            return Ok(await _mediatr.Send(updatedJobCommand));
        }

        [HttpDelete("/DeleteProduct/{jobId}")]
        [Authorize]
        public async Task<ActionResult<bool>> DeleteJob([FromRoute] int jobId)
        {
            DeleteJobCommand deleteJobCommand = new DeleteJobCommand()
            {
                JobId = jobId
            };
            return Ok(await _mediatr.Send(deleteJobCommand));
        }

        [HttpPost("/AddToInbox/{jobId}")]
        [Authorize]
        public async Task<ActionResult> AddToInbox([FromRoute] int jobId)
        {
            CreateInboxItemCommand createInboxItem = new CreateInboxItemCommand()
            {
                UserId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value),
                JobId = jobId,
                Name = User.FindFirst(c => c.Type == ClaimTypes.Name).Value

            };
            return Ok(await _mediatr.Send(createInboxItem));
        }
    }
}