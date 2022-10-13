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
        public async Task<ActionResult<ServiceResponse<List<Bleet>>>> GetBleets()
        {
            var result = await _bleetService.GetBleetsAsync();
            return Ok(result);
        }
    }
}
