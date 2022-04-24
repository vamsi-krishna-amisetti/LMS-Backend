using LibraryManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementApp.Interface
{
    public interface IBookStatus
    {
        Task<IEnumerable<BookStatus>> GetBookStatusAsync();
        Task<BookStatus> GetBookStatus(int bookStatusId);
        Task AddBookStatus(BookStatus bookStatus);
        Task<BookStatus> UpdateBookStatusAsync(BookStatus bookStatus);
        Task DeleteBookStatusAsync(int bookStatusId);
    }
}
