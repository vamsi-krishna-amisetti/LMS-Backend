using LibraryManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementApp.Interface
{
    public interface IIssue
    {
        Task<IEnumerable<Issue>> GetIssueAsync();
        Task<Issue> GetIssue(int issueId);
        Task AddIssue(Issue issue);
        Task<Issue> UpdateIssueAsync(Issue issueId);
        Task DeleteIssueAsync(int issueId);
    }
}
