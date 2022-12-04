using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaportMicroservice.Queries;
using RaportsMicroservice.Entities;
using RaportsMicroservice.Queries;

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
        public async Task<ActionResult<Raport>> GetRaport([FromRoute] int raportId)
        {
            GetRaportQuery getRaportQuery = new GetRaportQuery()
            {
                RaportId = raportId
            };
            return Ok(await _mediatr.Send(getRaportQuery));
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Raport>>> GetRaports()
        {
            return Ok(await _mediatr.Send(new GetRaportsQuery()));
        }
    }
}