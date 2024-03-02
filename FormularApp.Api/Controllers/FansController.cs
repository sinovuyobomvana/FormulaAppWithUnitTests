using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormularApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FansController : ControllerBase
    {
        [HttpGet("GetFans")]
        public async Task<IActionResult> Get()
        {
            return Ok("fans");
        }

    }
}
