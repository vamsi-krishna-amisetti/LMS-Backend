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
    public class DesignationRepository : IDesignation
    {
        private LibraryDBContext _context;
        public DesignationRepository(LibraryDBContext context)
        {
            _context = context;
        }
        public async Task AddDesignation(Designation designation)
        {
            await _context.Designations.AddAsync(designation);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteDesignationAsync(int designationId)
        {
            var bk = new Designation()
            {
                DesignationId = designationId
            };
            _context.Designations.Remove(bk);
            await _context.SaveChangesAsync();
        }
        public async Task<Designation> GetDesignation(int designationId)
        {
            var book = await _context.Designations.FindAsync(designationId);
            return book;
        }
        public async Task<IEnumerable<Designation>> GetDesignationAsync()
        {
            var records = await _context.Designations.ToListAsync();
            return records;
        }
        public async Task<Designation> UpdateDesignationAsync(Designation designation)
        {
            var bk = new Designation()
            {
                DesignationName = designation.DesignationName
            };
            _context.Designations.Update(bk);
            await _context.SaveChangesAsync();
            return bk;
        }
    }
}
