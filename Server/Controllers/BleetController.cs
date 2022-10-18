using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace BrightApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BleetController : ControllerBase
    {
        private readonly IBleetService _bleetService;

        public BleetController(IBleetService bleetService)
        {
            _bleetService = bleetService;
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
            return Ok(result);
        }
    }
}
