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
    public class FacultyRepository : IFaculty
    {
        private LibraryDBContext _context;
        public FacultyRepository(LibraryDBContext context)
        {
            _context = context;
        }
        public async Task AddFaculty(Faculty faculty)
        {
            await _context.Faculties.AddAsync(faculty);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteFacultyAsync(string facultyId)
        {
            var bk = new Faculty()
            {
                FacultyId = facultyId
            };
            _context.Faculties.Remove(bk);
            await _context.SaveChangesAsync();
        }
        public async Task<Faculty> GetFaculty(int facultyId)
        {
            var book = await _context.Faculties.FindAsync(facultyId);
            return book;
        }
        public async Task<IEnumerable<Faculty>> GetFacultyAsync()
        {
            var records = await _context.Faculties.ToListAsync();
            return records;
        }
        public async Task<Faculty> UpdateFacultyAsync(Faculty faculty)
        {
            var bk = new Faculty()
            {
                FacultyName = faculty.FacultyName,
                FacultyEmail = faculty.FacultyEmail,
                FacultyPhone = faculty.FacultyPhone,
                FacultyAddress = faculty.FacultyAddress,
                Designation = faculty.Designation
            };
            _context.Faculties.Update(bk);
            await _context.SaveChangesAsync();
            return bk;
        }
    }
}
