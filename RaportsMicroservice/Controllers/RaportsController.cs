using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaportMicroservice.Queries;
using RaportsMicroservice.Commands.UserRaportRecordCommands;
using RaportsMicroservice.Dtos;
using System.Security.Claims;

namespace RaportsMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RaportsController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public RaportsController(IMediator mediatr)
        {
            _mediatr = mediatr ?? throw new ArgumentNullException(nameof(mediatr));
        }

        [HttpGet("/{id}")]
        [Authorize]
        public async Task<ActionResult> GetRaport([FromRoute] int raportId)
        {
            GetRaportQuery getRaportQuery = new GetRaportQuery()
            {
                RaportId = raportId
            };
            return Ok(await _mediatr.Send(getRaportQuery));
        }

        [HttpPut("/{id}/record/{record}")]
        [Authorize]
        public async Task<ActionResult> UpdateUserRaportRecord(
            [FromRoute] int id, 
            [FromRoute] int record, 
            [FromBody] UpdateDto recordUpdate)
        {
            UpdateUserRaportRecordCommand command = new UpdateUserRaportRecordCommand()
            { 
                RaportId = id,
                UserId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value),
                UserRecordId = record,
                TaskHours = recordUpdate.TaskHours,
                System=recordUpdate.System,
                Ecm=recordUpdate.Ecm,
                Gpdm=recordUpdate.Gpdm,
                ProjectNumber= recordUpdate.ProjectNumber,
                Components = recordUpdate.Gpdm,
                DrawingOfComponent = recordUpdate.Gpdm,
                DrawingOfAssemblies = recordUpdate.Gpdm,
                DueDate = recordUpdate.DueDate,
                StartedDate = recordUpdate.StartedDate,
                FinishedDate = recordUpdate.FinishedDate,
                Client = recordUpdate.Client,
            };
            return Ok(await _mediatr.Send(command));
        }

        [HttpDelete("/{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteUserRaportRecord([FromRoute] int id )
        {
            DeleteUserRaportRecordCommand command = new DeleteUserRaportRecordCommand()
            {
                UserRaportRecordId = id
            };
            return Ok(await _mediatr.Send(command));
        }
    }
}