using LibraryManagementApp.DBContext;
using LibraryManagementApp.Interface;
using LibraryManagementApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementApp.Repository
{
    public class IssueRepository : IIssue
    {
        private LibraryDBContext _context;
        public IssueRepository(LibraryDBContext context)
        {
            _context = context;
        }
        public async Task AddIssue(Issue issue)
        {
            await _context.Issues.AddAsync(issue);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteIssueAsync(int issueId)
        {
            var bk = new Issue()
            {
                IssueId = issueId
            };
            _context.Issues.Remove(bk);
            await _context.SaveChangesAsync();
        }
        public async Task<Issue> GetIssue(int issueId)
        {
            var issue = await _context.Issues.FindAsync(issueId);
            return issue;
        }
        public async Task<IEnumerable<Issue>> GetIssueAsync()
        {
            var records = await _context.Issues.ToListAsync();
            return records;
        }
        public async Task<Issue> UpdateIssueAsync(Issue issue)
        {
            var bk = new Issue()
            {
                StudentId = issue.StudentId,
                BookId = issue.BookId,
                Message = issue.Message
            };
            _context.Issues.Update(bk);
            await _context.SaveChangesAsync();
            return bk;
        }
    }
}
