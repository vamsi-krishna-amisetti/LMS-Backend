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
    public class EBookController : ControllerBase
    {
        private readonly IEBook _iEBook;
        public EBookController(IEBook iEBook)
        {
            _iEBook = iEBook;
        }
        // GET: api/<EBookController>
        [HttpGet("")]
        public async Task<IEnumerable<EBook>> GetEbookAsync()
        {
            var details = await _iEBook.GetEbookAsync();
            return details;
        }
        // GET api/<EBookController>/5
        [HttpGet("{eBookId}")]
        [ActionName("GetEBook")]
        public async Task<IActionResult> GetEbook([FromRoute] int eBookId)
        {
            var detail = await _iEBook.GetEbook(eBookId);
            if (detail != null)
            {
                return Ok(detail);
            }
            return NotFound(" Not Found");
        }
        // POST api/<EBookController>
        [HttpPost("")]
        public async Task<IActionResult> AddEbook([FromBody] EBook eBook)
        {
            await _iEBook.AddEbook(eBook);
            return CreatedAtAction(nameof(GetEbook), new { eBookId = eBook.EBookId }, eBook);
        }
        // PUT api/<EBookController>/5
        [HttpPut("")]
        public async Task<IActionResult> UpdateEbookAsync([FromBody] EBook eBook)
        {
            var detail = await _iEBook.UpdateEbookAsync(eBook);
            if (detail != null)
            {
                return Ok(detail);
            }
            else
            {
                return NotFound(" not found");
            }
        }
        // DELETE api/<EBookController>/5
        [HttpDelete("{eBookId}")]
        public async Task<IActionResult> DeleteEbookAsync([FromRoute] int eBookId)
        {
            await _iEBook.DeleteEbookAsync(eBookId);
            return Ok();
        }
    }
}
