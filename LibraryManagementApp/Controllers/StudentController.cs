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
    public class StudentController : ControllerBase
    {
        private readonly IStudent _iStudent;
        public StudentController(IStudent iStudent)
        {
            _iStudent = iStudent;
        }
        // GET: api/<StudentController>
        [HttpGet("")]
        public async Task<IEnumerable<Student>> GetStudentAsync()
        {
            var details = await _iStudent.GetStudentAsync();
            return details;
        }
        // GET api/<StudentController>/5
        [HttpGet("{studentId}")]
        [ActionName("GetStudent")]
        public async Task<IActionResult> GetStudent([FromRoute] int studentId)
        {
            var detail = await _iStudent.GetStudent(studentId);
            if (detail != null)
            {
                return Ok(detail);
            }
            return NotFound(" Not Found");
        }
        // POST api/<StudentController>
        [HttpPost("")]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            await _iStudent.AddStudent(student);
            return CreatedAtAction(nameof(GetStudent), new { studentId = student.StudentId }, student);
        }
        // PUT api/<StudentController>/5
        [HttpPut("")]
        public async Task<IActionResult> UpdateStudentAsync([FromBody] Student student)
        {
            var detail = await _iStudent.UpdateStudentAsync(student);
            if (detail != null)
            {
                return Ok(detail);
            }
            else
            {
                return NotFound(" not found");
            }
        }
        // DELETE api/<StudentController>/5
        [HttpDelete("{studentId}")]
        public async Task<IActionResult> DeleteStudentAsync([FromRoute] int studentId)
        {
            await _iStudent.DeleteStudentAsync(studentId);
            return Ok();
        }
    }
}
