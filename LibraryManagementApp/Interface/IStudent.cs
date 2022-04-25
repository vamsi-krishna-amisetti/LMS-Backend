using LibraryManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementApp.Interface
{
    public interface IStudent
    {
        Task<IEnumerable<Student>> GetStudentAsync();
        Task<Student> GetStudent(int studentId);
        Task AddStudent(Student student);
        Task<Student> UpdateStudentAsync(Student studentId);
        Task DeleteStudentAsync(int studentId);
    }
}
