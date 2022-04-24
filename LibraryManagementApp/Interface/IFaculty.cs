using LibraryManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementApp.Interface
{
    public interface IFaculty
    {
        Task<IEnumerable<Faculty>> GetFacultyAsync();
        Task<Faculty> GetFaculty(int facultyId);
        Task AddFaculty(Faculty faculty);
        Task<Faculty> UpdateFacultyAsync(Faculty faculty);
        Task DeleteFacultyAsync(string facultyId);
    }
}
