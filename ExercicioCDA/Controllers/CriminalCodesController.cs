using ExercicioCDA.Models;
using ExercicioCDA.Models.Entities.CriminalCodes;
using ExercicioCDA.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using X.PagedList;

namespace ExercicioCDA.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CriminalCodesController : ControllerBase
    {
        private readonly ICriminalRepository repos;
        private readonly _DbContext db;

        public CriminalCodesController(ICriminalRepository _repos, _DbContext _db)
        {
            repos = _repos;
            db = _db;
        }

        /// <summary>
        /// Get all the criminal codes and return.
        /// </summary>
        /// <param name="page"></param>
        [HttpGet]
        [Route("all")]
        [Authorize]
        public IActionResult Index(int page = 1)
        {
            var codes = db.CriminalCodes.OrderBy(p => p.Id).ToPagedList(page, 10);
            return Ok(codes);
        }

        /// <summary>
        /// Filter and order criminal codes.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("filter")]
        [Authorize]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Filter |
                                           AllowedQueryOptions.OrderBy |
                                           AllowedQueryOptions.Select)]
        public IQueryable<CriminalCodes> FilterCodes()
        {
            return db.CriminalCodes;
        }

        /// <summary>
        /// Get the criminal code using the ID.
        /// </summary>
        /// <param name="criminalcode"></param>
        /// <returns>Criminal code for ID</returns>
        [HttpGet("{Id}")]
        [Authorize]
        public IActionResult Get([FromRoute]CriminalCodeId criminalcode)
        {
            var criminalcode_db = repos.Read(criminalcode.Id);
            return Ok(criminalcode_db);
        }

        /// <summary>
        /// Register new criminal code in database.
        /// </summary>
        /// <param name="postcriminalcode"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public IActionResult Post(PostCriminalCodes postcriminalcode)
        {
            if (repos.Create(postcriminalcode))
            {
                return Ok();
            }
            return BadRequest();
        }

        /// <summary>
        /// Update criminal codes.
        /// </summary>
        /// <param name="putcriminalcode"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        public IActionResult Put(PutCriminalCodes putcriminalcode)
        {
            if (repos.Update(putcriminalcode))
            {
                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Delete criminal codes of database using the ID.
        /// </summary>
        /// <param name="criminalcode"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        [Authorize]
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
