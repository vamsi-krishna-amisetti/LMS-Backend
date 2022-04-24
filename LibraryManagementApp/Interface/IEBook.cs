using LibraryManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementApp.Interface
{
    public interface IEBook
    {
        Task<IEnumerable<EBook>> GetEbookAsync();
        Task<EBook> GetEbook(int eBookId);
        Task AddEbook(EBook eBook);
        Task<EBook> UpdateEbookAsync(EBook eBookId);
        Task DeleteEbookAsync(int eBookId);

    }
}
