using BooksApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Business.Abstract
{
    public interface IBookService
    {
        #region Generic
        Task<Book> GetByIdAsync(int id);
        Task<List<Book>> GetAllAsync();
        Task CreateAsync(Book book);
        void Update(Book book);
        void Delete(Book book);
        #endregion

        #region Book
        Task<List<Book>> GetBooksWithFullDataAsync(bool? isHome = null, bool? isActive=null);
        Task<List<Book>> GetAllActiveBooksAsync(string categoryUrl=null, string authorUrl=null, string publisherUrl=null);
        Task<Book> GetBookByUrlAsync(string bookUrl);
        Task<Book> GetBookByIdAsync(int id);
        Task<List<Book>> GetAllBooksWithAuthorAndPublisher(bool isDeleted);
        Task CreateBookAsync(Book book, List<int> SelectedCategoryIds);
        Task UpdateAuthorOfBooks();
        Task UpdatePublisherOfBooks();
        Task CheckBooksCategories();
        void UpdateBook(Book book);
        #endregion
    }
}
