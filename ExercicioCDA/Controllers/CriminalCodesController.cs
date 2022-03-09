using ExercicioCDA.Models;
using ExercicioCDA.Models.Entities.CriminalCodes;
using ExercicioCDA.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExercicioCDA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriminalCodesController : ControllerBase
    {
        private readonly ICriminalRepository repos;

        public CriminalCodesController(ICriminalRepository _repos)
        {
            repos = _repos;
        }

        /// <summary>
        /// Get the criminal code using the ID.
        /// </summary>
        /// <param name="criminalcode"></param>
        /// <returns>Criminal code for ID</returns>

        [Authorize]
        [HttpGet("{Id}")]
        public IActionResult Get([FromRoute]CriminalCodeId criminalcode)
        {
            var criminalcode_db = repos.Read(criminalcode.Id);
            return Ok(criminalcode_db);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(PostCriminalCodes postcriminalcode)
        {
            if (repos.Create(postcriminalcode))
            {
                return Ok();
            }
            return BadRequest();
        }

        [Authorize]
        [HttpPut]
        public IActionResult Put(PutCriminalCodes putcriminalcode)
        {
            if (repos.Update(putcriminalcode))
            {
                return Ok();
            }

            return BadRequest();
        }

        [Authorize]
        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] CriminalCodeId criminalcode)
        {
            if (repos.Delete(criminalcode.Id))
            {
                return Ok();
            }
            return BadRequest();
        }
    
    }
}
