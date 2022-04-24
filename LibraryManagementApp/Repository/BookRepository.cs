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
    public class BookRepository : IBook
    {
        private LibraryDBContext _context;
        public BookRepository(LibraryDBContext context)
        {
            _context = context;
        }
        public async Task AddBook(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteBookAsync(int bookId)
        {
            var bk = new Book()
            {
                BookId = bookId
            };
            _context.Books.Remove(bk);
            await _context.SaveChangesAsync();
        }
        public async Task<Book> GetBook(int bookid)
        {
            var book = await _context.Books.FindAsync(bookid);
            return book;
        }
        public async Task<IEnumerable<Book>> GetBookAsync()
        {
            var records = await _context.Books.ToListAsync();
            return records;
        }
        public async Task<Book> UpdateBookAsync(Book book)
        {
            var bk = new Book()
            {
                BookId = book.BookId,
                BookName = book.BookName,
                ISBN = book.ISBN,
                Description = book.Description,
                Publisher = book.Publisher,
                Author = book.Author,
                Location = book.Location,
                Quantity = book.Quantity,
                Issued = book.Issued,
                BookStatus = book.BookStatus
            };
            _context.Books.Update(bk);
            await _context.SaveChangesAsync();
            return bk;
        }
    }
}
