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
    public class BookStatusRepository : IBookStatus
    {
        private LibraryDBContext _context;
        public BookStatusRepository(LibraryDBContext context)
        {
            _context = context;
        }
        public async Task AddBookStatus(BookStatus bookStatus)
        {
            await _context.BookStatuses.AddAsync(bookStatus);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteBookStatusAsync(int bookStatusId)
        {
            var bk = new BookStatus()
            {
                BookStatusId = bookStatusId
            };
            _context.BookStatuses.Remove(bk);
            await _context.SaveChangesAsync();
        }
        public async Task<BookStatus> GetBookStatus(int bookStatusId)
        {
            var book = await _context.BookStatuses.FindAsync(bookStatusId);
            return book;
        }
        public async Task<IEnumerable<BookStatus>> GetBookStatusAsync()
        {
            var records = await _context.BookStatuses.ToListAsync();
            return records;
        }
        public async Task<BookStatus> UpdateBookStatusAsync(BookStatus bookStatus)
        {
            var bk = new BookStatus()
            {
                Status = bookStatus.Status
            };
            _context.BookStatuses.Update(bk);
            await _context.SaveChangesAsync();
            return bk;
        }
    }

}
