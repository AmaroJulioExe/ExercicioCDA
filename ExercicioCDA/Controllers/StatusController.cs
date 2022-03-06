using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExercicioCDA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
