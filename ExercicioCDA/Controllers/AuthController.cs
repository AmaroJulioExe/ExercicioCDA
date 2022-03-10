using ExercicioCDA.Models;
using ExercicioCDA.Repositories;
using ExercicioCDA.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExercicioCDA.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository repos;

        public AuthController(IUserRepository _repos)
        {
            repos = _repos;
        }

        /// <summary>
        /// Authentication System
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login([FromBody] Users users)
        {
            try
            {
                var user_db = repos.Get(users.Username, users.Password);

                if (user_db == null)
                {
                    return BadRequest(new { message = "Usuário ou senha incorretos." });
                }

                if (user_db.Password != users.Password)
                {
                    return BadRequest(new { message = "Usuário ou senha incorretos." });
                }

                var token = TokenService.GenerateToken(user_db);

                return Ok(new
                {
                    user = users,
                    _token = token
                });
            }
            catch 
            {
                return BadRequest(new { messeage = "Ocorreu um erro. Tente novamente." });
            }
        }
    }
}
