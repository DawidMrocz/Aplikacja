using CatsApiMicroservice.Entities;
using CatsApiMicroservice.Queries;
using CatsApiMicroservice.Queries.CatQueries;
using CatsApiMicroservice.Queries.EmployeeQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CatsApiMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserCatssController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserCatssController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/allCats")]
        [Authorize]
        public async Task<ActionResult<Employee>> GetAllCats()
        {
            GetEmployeeQuery getAllUserCatsQuery = new GetEmployeeQuery()
            {
                UserId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value),
            };
            return Ok(await _mediator.Send(getAllUserCatsQuery));
        }

        [HttpGet("/Cat/{catId}")]
        [Authorize]
        public async Task<ActionResult<Cat>> GetCurrentCats([FromRoute] int catId)
        {
            GetCatQuery getUserCatsQuery = new GetCatQuery()
            {
                UserId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value),
                CatId = catId
            };
            return Ok(await _mediator.Send(getUserCatsQuery));
        }

        [HttpDelete("/{id}")]
        [Authorize]
        public async Task<ActionResult<bool>> DeleteUserCatsRecordHours([FromRoute] int UserCatsId)
        {
            return NoContent();
        }

        [HttpDelete("/{id}")]
        [Authorize]
        public async Task<ActionResult<bool>> UpdateUserCatsRecordHours([FromRoute] int UserCatsId)
        {
            return NoContent();
        }
    }
}