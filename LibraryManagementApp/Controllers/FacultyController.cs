using LibraryManagementApp.Interface;
using LibraryManagementApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacultyController : ControllerBase
    {
        private readonly IFaculty _iFaculty;
        public FacultyController(IFaculty iFaculty)
        {
            _iFaculty = iFaculty;
        }
        // GET: api/<FacultyController>
        [HttpGet("")]
        public async Task<IEnumerable<Faculty>> GetFacultyAsync()
        {
            var details = await _iFaculty.GetFacultyAsync();
            return details;
        }
        // GET api/<FacultyController>/5
        [HttpGet("{facultyId}")]
        [ActionName("GetFaculty")]
        public async Task<IActionResult> GetFaculty([FromRoute] int facultyId)
        {
            var detail = await _iFaculty.GetFaculty(facultyId);
            if (detail != null)
            {
                return Ok(detail);
            }
            return NotFound(" Not Found");
        }
        // POST api/<FacultyController>
        [HttpPost("")]
        public async Task<IActionResult> AddFaculty([FromBody] Faculty faculty)
        {
            await _iFaculty.AddFaculty(faculty);
            return CreatedAtAction(nameof(GetFaculty), new { facultyId = faculty.FacultyId }, faculty);
        }
        // PUT api/<FacultyController>/5
        [HttpPut("")]
        public async Task<IActionResult> UpdateFacultyAsync([FromBody] Faculty faculty)
        {
            var detail = await _iFaculty.UpdateFacultyAsync(faculty);
            if (detail != null)
            {
                return Ok(detail);
            }
            else
            {
                return NotFound(" not found");
            }
        }
        // DELETE api/<FacultyController>/5
        [HttpDelete("{facultyId}")]
        public async Task<IActionResult> DeleteFacultyAsync([FromRoute] string facultyId)
        {
            await _iFaculty.DeleteFacultyAsync(facultyId);
            return Ok();
        }
    }
}
