using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace BrightApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BleetController : ControllerBase
    {
        private readonly BleetContext _context;

        public BleetController(BleetContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Bleet>>> GetBleet()
        {
            var bleets = await _context.Bleets.ToListAsync();
            return Ok(bleets);
        }
    }
}
