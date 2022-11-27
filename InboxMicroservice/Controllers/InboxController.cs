using InboxMicroservice.Entities;
using InboxMicroservice.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InboxMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InboxController : ControllerBase
    {
        private readonly IInboxRepository _inboxRepository;
        //private readonly MyOrderGrpcService _orderGrpcService;

        public InboxController(IInboxRepository InboxRepository)
        {
            _inboxRepository = InboxRepository;
            //_orderGrpcService = orderGrpcService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Inbox>> GetMyInbox()
        {
            var authenticatedId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            return Ok(await _inboxRepository.GetMyInbox(authenticatedId));
        }

        [HttpGet("/Inboxs")]
        public async Task<ActionResult<List<Inbox>>> GetInboxs()
        {
            return Ok(await _inboxRepository.GetInboxs());
        }

        [HttpPost("/addOrder")]
        [Authorize]
        public async Task CreateOrder()
        {
            var authenticatedId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            //await _orderGrpcService.CreateOrder(authenticatedId);
        }
    }
}