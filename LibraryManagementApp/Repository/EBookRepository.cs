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
    public class EbookRepository : IEBook
    {
        private LibraryDBContext _context;
        public EbookRepository(LibraryDBContext context)
        {
            _context = context;
        }
        public async Task AddEbook(EBook eBook)
        {
            await _context.EBooks.AddAsync(eBook);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteEbookAsync(int eBookId)
        {
            var bk = new EBook()
            {
                EBookId = eBookId
            };
            _context.EBooks.Remove(bk);
            await _context.SaveChangesAsync();
        }
        public async Task<EBook> GetEbook(int eBookId)
        {
            var book = await _context.EBooks.FindAsync(eBookId);
            return book;
        }
        public async Task<IEnumerable<EBook>> GetEbookAsync()
        {
            var records = await _context.EBooks.ToListAsync();
            return records;
        }
        public async Task<EBook> UpdateEbookAsync(EBook eBook)
        {
            var bk = new EBook()
            {
                EBookName = eBook.EBookName,
                ISBN = eBook.ISBN,
                Description = eBook.Description,
                Publisher = eBook.Publisher,
                Author = eBook.Author
            };
            _context.EBooks.Update(bk);
            await _context.SaveChangesAsync();
            return bk;
        }
    }
}
