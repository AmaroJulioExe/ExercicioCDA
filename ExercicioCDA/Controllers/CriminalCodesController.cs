﻿using ExercicioCDA.Models;
using ExercicioCDA.Models.Entities.CriminalCodes;
using ExercicioCDA.Repositories;
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

        [HttpGet("{Id}")]
        public IActionResult Get([FromRoute]CriminalCodeId criminalcode)
        {
            var criminalcode_db = repos.Read(criminalcode.Id);
            return Ok(criminalcode_db);
        }

        [HttpPost]
        public IActionResult Post(PostCriminalCodes postcriminalcode)
        {
            if (repos.Create(postcriminalcode))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
    
    }
}
