using ExercicioCDA.Models;
using ExercicioCDA.Repositories;
using ExercicioCDA.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExercicioCDA.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult GetHome()
        {
            return Ok(value: "Bem vindo, " + User.Identity.Name);
        }
    }
}
