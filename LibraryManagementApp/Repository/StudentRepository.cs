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
    public class StudentRepository : IStudent
    {
        private LibraryDBContext _context;
        public StudentRepository(LibraryDBContext context)
        {
            _context = context;
        }
        public async Task AddStudent(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteStudentAsync(int studentId)
        {
            var bk = new Student()
            {
                StudentId = studentId
            };
            _context.Students.Remove(bk);
            await _context.SaveChangesAsync();
        }
        public async Task<Student> GetStudent(int studentId)
        {
            var student = await _context.Students.FindAsync(studentId);
            return student;
        }
        public async Task<IEnumerable<Student>> GetStudentAsync()
        {
            var records = await _context.Students.ToListAsync();
            return records;
        }
        public async Task<Student> UpdateStudentAsync(Student student)
        {
            var bk = new Student()
            {
                StudentName = student.StudentName,
                StunentEmail = student.StunentEmail,
                FatherName = student.FatherName,
                Password = student.Password,
                Phone = student.Phone,
                Address = student.Address,
                Class = student.Class,
                RollNo = student.RollNo
            };
            _context.Students.Update(bk);
            await _context.SaveChangesAsync();
            return bk;
        }
    }
}
