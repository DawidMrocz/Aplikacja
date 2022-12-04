using InboxMicroservice.Commands.CatsCommands;
using InboxMicroservice.Commands.InboxItemCommands;
using InboxMicroservice.Dtos;
using InboxMicroservice.Entities;
using InboxMicroservice.GrpcSerivce;
using InboxMicroservice.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using IMediator = MediatR.IMediator;

namespace InboxMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InboxController : ControllerBase
    {
        private readonly ICatsGrpcService _catsGrpcService;
        private readonly IMediator _mediator;

        public InboxController(ICatsGrpcService catsGrpcService, IMediator mediator)
        {
            _mediator = mediator;
            _catsGrpcService = catsGrpcService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Inbox>> GetMyInbox()
        {
            GetMyInboxQuery getMyInboxQuery = new GetMyInboxQuery()
            {
                UserId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value),
            };
            return Ok(await _mediator.Send(getMyInboxQuery));
        }



        [HttpPost("/data/{inboxItemId}")]
        [Authorize]
        public async Task<ActionResult<int>> CreateData([FromBody] CatDto sendDto, [FromRoute] int inboxItemId)
        {
            CreateDataCommand createDataCommand = new CreateDataCommand()
            {
                UserId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value),
                Name = User.FindFirst(c => c.Type == ClaimTypes.Name).Value,
                InboxItemId = inboxItemId,
                Hours = sendDto.Hours,
                EntryDate = sendDto.EntryDate,
            };
            double updatedHours = await _mediator.Send(createDataCommand);

            return Ok(updatedHours);
        }

        [HttpPut("/data/{inboxItemId}")]
        [Authorize]
        public async Task<ActionResult<double>> UpdateData([FromBody] CatDto updateDto, [FromRoute] int inboxItemId)
        {
            UpdateDataCommand updateDataCommand = new UpdateDataCommand()
            {
                UserId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value),
                Name = User.FindFirst(c => c.Type == ClaimTypes.Name).Value,
                InboxItemId = inboxItemId,
                Hours = updateDto.Hours,
                EntryDate = updateDto.EntryDate,
            };
            return Ok(await _mediator.Send(updateDataCommand));
        }

        [HttpDelete("/data/{inboxItemId}")]
        [Authorize]
        public async Task<ActionResult> DeleteData([FromBody] string entryDate, [FromRoute] int inboxItemId)
        {
            DeleteDataCommand deleteDataCommand = new DeleteDataCommand()
            {
                InboxItemId = inboxItemId,
                EntryData = entryDate,
            };
            return Ok(await _mediator.Send(deleteDataCommand));
        }

        [HttpDelete("/inboxitem/{inboxItemId}")]
        [Authorize]
        public async Task<ActionResult<bool>> DeleteInboxItemFromInbox([FromRoute] int inboxItemId)
        {
            DeleteInboxItemFromInboxCommand command = new DeleteInboxItemFromInboxCommand
            {
                UserId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value),
                InboxItemId=inboxItemId,
            };

            return Ok(await _mediator.Send(command));
        }

        [HttpPut("/inboxitem/{inboxItemId}")]
        [Authorize]
        public async Task<ActionResult<bool>> UpdateInboxItemFromInbox([FromBody] UpdateJobDto updateJobDto ,[FromRoute] int inboxItemId)
        {
            UpdateInboxItemFromInboxCommand command = new UpdateInboxItemFromInboxCommand
            {
                UserId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value),
                InboxItemId = inboxItemId,
                Status = updateJobDto.Status,
                Components = updateJobDto.Components,
                DrawingsComponents = updateJobDto.DrawingsComponents,
                DrawingsAssembly = updateJobDto.DrawingsAssembly,
                WhenComplete=  updateJobDto.WhenComplete,
                Started = updateJobDto.Started,
                Finished=  updateJobDto.Finished,
            };
            return Ok(await _mediator.Send(command));
        }

    }
}