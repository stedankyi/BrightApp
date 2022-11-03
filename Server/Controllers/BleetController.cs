using BrightApp.Server.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace BrightApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class BleetController : ControllerBase
    {
        private readonly IHubContext<BleetHub> _bleetHubContext;
        private readonly IBleetService _bleetService;

        public BleetController(IBleetService bleetService, IHubContext<BleetHub> bleetHubContext)
        {
            _bleetService = bleetService;
            _bleetHubContext = bleetHubContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Bleet>>> GetBleets()
        {
            var result = await _bleetService.GetBleetsAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Bleet>> CreateBleet(Bleet bleet)
        {
            var result = await _bleetService.CreateBleet(bleet);
            await _bleetHubContext.Clients.All.SendAsync("ReceiveBleets");
            return Ok(result);
        }
    }
}
