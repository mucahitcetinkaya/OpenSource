using BooksApp.Business.Abstract;
using BooksApp.Data.Abstract;
using BooksApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Business.Concrete
{
    public class BookManager : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookManager(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task CreateAsync(Book book)
        {
            await _bookRepository.CreateAsync(book);
        }

        public void Delete(Book book)
        {
            _bookRepository.Delete(book);
        }

        public async Task<List<Book>> GetAllAsync()
        {
            var result = await _bookRepository.GetAllAsync();
            return result;
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            var result = await _bookRepository.GetByIdAsync(id);
            return result;
        }

        public void Update(Book book)
        {
            _bookRepository.Update(book);
        }

        public async Task<List<Book>> GetBooksWithFullDataAsync(bool? isHome = null, bool? isActive = null)
        {
            var result = await _bookRepository.GetBooksWithFullDataAsync(isHome, isActive);
            return result;
        }

        public async Task<List<Book>> GetAllActiveBooksAsync(string categoryUrl = null, string authorUrl = null, string publisherUrl = null)
        {
            var result = await _bookRepository.GetAllActiveBooksAsync(categoryUrl, authorUrl, publisherUrl);
            return result;
        }

        public async Task<Book> GetBookByUrlAsync(string bookUrl)
        {
            var result = await _bookRepository.GetBookByUrlAsync(bookUrl);
            return result;
        }

        public async Task<List<Book>> GetAllBooksWithAuthorAndPublisher(bool isDeleted)
        {
            var result = await _bookRepository.GetAllBooksWithAuthorAndPublisher(isDeleted);
            return result;
        }

        public async Task CreateBookAsync(Book book, List<int> SelectedCategoryIds)
        {
            await _bookRepository.CreateBookAsync(book, SelectedCategoryIds);
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetBookByIdAsync(id);
        }

        public async Task UpdateAuthorOfBooks()
        {
            await _bookRepository.UpdateAuthorOfBooks();
        }

        public async Task UpdatePublisherOfBooks()
        {
            await _bookRepository.UpdatePublisherOfBooks();
        }

        public async Task CheckBooksCategories()
        {
            await _bookRepository.CheckBooksCategories();
        }

        public void UpdateBook(Book book)
        {
            _bookRepository.UpdateBook(book);
        }
    }
}
