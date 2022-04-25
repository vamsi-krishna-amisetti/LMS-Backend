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
    public class IssueController : ControllerBase
    {
        private readonly IIssue _iIssue;
        public IssueController(IIssue iIssue)
        {
            _iIssue = iIssue;
        }
        // GET: api/<IssueController>
        [HttpGet("")]
        public async Task<IEnumerable<Issue>> GetIssueAsync()
        {
            var details = await _iIssue.GetIssueAsync();
            return details;
        }
        // GET api/<IssueController>/5
        [HttpGet("{issueId}")]
        [ActionName("GetIssue")]
        public async Task<IActionResult> GetIssue([FromRoute] int issueId)
        {
            var detail = await _iIssue.GetIssue(issueId);
            if (detail != null)
            {
                return Ok(detail);
            }
            return NotFound(" Not Found");
        }
        // POST api/<IssueController>
        [HttpPost("")]
        public async Task<IActionResult> AddIssue([FromBody] Issue issue)
        {
            await _iIssue.AddIssue(issue);
            return CreatedAtAction(nameof(GetIssue), new { issueId = issue.IssueId }, issue);
        }
        // PUT api/<IssueController>/5
        [HttpPut("")]
        public async Task<IActionResult> UpdateIssueAsync([FromBody] Issue issue)
        {
            var detail = await _iIssue.UpdateIssueAsync(issue);
            if (detail != null)
            {
                return Ok(detail);
            }
            else
            {
                return NotFound(" not found");
            }
        }
        // DELETE api/<IssueController>/5
        [HttpDelete("{issueId}")]
        public async Task<IActionResult> DeleteIssueAsync([FromRoute] int issueId)
        {
            await _iIssue.DeleteIssueAsync(issueId);
            return Ok();
        }
    }
}
