using BooksApp.Core;
using BooksApp.Data.Abstract;
using BooksApp.Data.Concrete.EfCore.Contexts;
using BooksApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Data.Concrete.EfCore.Repositories
{
    public class EfCoreBookRepository : EfCoreGenericRepository<Book>, IBookRepository
    {
        public EfCoreBookRepository(BooksAppContext _context):base(_context)
        {
            
        }

        private BooksAppContext Context
        {
            get { return _dbContext as BooksAppContext; }
        }

        public async Task CheckBooksCategories()
        {
            var bookCategoryIds = await Context
                .BookCategories
                .Select(bc => bc.BookId)
                .Distinct()
                .ToListAsync();
            var bookIds = await Context
                .Books
                .Select(b => b.Id)
                .ToListAsync();
            List<int> different = bookIds.Except(bookCategoryIds).ToList();
            #region ForEach ile Çözüm
            //List<int> different = new List<int>();
            //bool exists;
            //foreach ( var bookId in bookIds )
            //{
            //    exists = false;
            //    foreach (var bookCategoryId in bookCategoryIds)
            //    {
            //        if (bookId==bookCategoryId)
            //        {
            //            exists = true;
            //            break;
            //        }
            //    }
            //    if (!exists) different.Add(bookId);
            //}
            #endregion
            await Context.BookCategories.AddRangeAsync(different.Select(d => new BookCategory
            {
                BookId=d,
                CategoryId=1
            }).ToList());
            await Context.SaveChangesAsync();
        }

        public async Task CreateBookAsync(Book book, List<int> SelectedCategoryIds)
        {
            await Context.Books.AddAsync(book);
            await Context.SaveChangesAsync();
            book.BookCategories = SelectedCategoryIds.Select(sc => new BookCategory
            {
                BookId = book.Id,
                CategoryId = sc
            }).ToList();
            Context.Books.Update(book);
            await Context.SaveChangesAsync();


            //List<BookCategory> bookCategories = new List<BookCategory>();
            //foreach (var categoryId in SelectedCategoryIds)
            //{
            //    bookCategories.Add(new BookCategory
            //    {
            //        BookId = book.Id,
            //        CategoryId = categoryId
            //    });
            //}
            //book.BookCategories = bookCategories;
            //_context.Books.Update(book);
            //await _context.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAllActiveBooksAsync(string categoryUrl = null, string authorUrl = null, string publisherUrl = null)
        {

            var result = Context
                .Books
                .Where(b => b.IsActive && !b.IsDeleted)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .AsQueryable();
            if (categoryUrl != null)
            {
                result = result
                    .Include(b => b.BookCategories)
                    .ThenInclude(bc => bc.Category)
                    .Where(b => b.BookCategories.Any(bc => bc.Category.Url == categoryUrl))
                    .AsQueryable();
            }
            if (authorUrl != null)
            {
                result = result
                    .Where(b => b.Author.Url == authorUrl)
                    .AsQueryable();
            }
            if (publisherUrl != null)
            {
                result = result
                    .Where(b => b.Publisher.Url == publisherUrl)
                    .AsQueryable();
            }
            return await result.ToListAsync();
        }

        public async Task<List<Book>> GetAllBooksWithAuthorAndPublisher(bool isDeleted)
        {
            var result = await Context
                .Books
                .Where(b => b.IsDeleted == isDeleted)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .ToListAsync();
            return result;
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var result = await Context
                .Books
                .Where(b => b.IsActive && !b.IsDeleted && b.Id == id)
                .Include(b => b.BookCategories)
                .ThenInclude(bc => bc.Category)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<Book> GetBookByUrlAsync(string bookUrl)
        {
            var result = await Context
                .Books
                .Where(b => b.IsActive && !b.IsDeleted && b.Url == bookUrl)
                .Include(b => b.BookCategories)
                .ThenInclude(bc => bc.Category)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<Book>> GetBooksWithFullDataAsync(bool? isHome = null, bool? isActive = null)
        {
            var result = Context
                .Books
                .Where(b => !b.IsDeleted)
                .AsQueryable();

            if (isHome != null)
            {
                result = result
                    .Where(b => b.IsHome == isHome)
                    .AsQueryable();
            }

            if (isActive != null)
            {
                result = result
                    .Where(b => b.IsActive == isActive)
                    .AsQueryable();
            }
            result = result
                .Include(b => b.BookCategories)
                .ThenInclude(bc => bc.Category)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .AsQueryable();

            return await result.ToListAsync();
        }

        public async Task UpdateAuthorOfBooks()
        {
            var books = await Context
                .Books
                .Where(b => b.AuthorId == null)
                .ToListAsync();
            foreach (var book in books)
            {
                book.AuthorId = 1;
            };
            Context.Books.UpdateRange(books);
            await Context.SaveChangesAsync();
        }

        public void UpdateBook(Book book)
        {
            Book oldBook = Context
                .Books
                .Include(b => b.BookCategories)
                .ThenInclude(bc => bc.Category)
                .Include(b => b.Author)
                .Include(p => p.Publisher)
                .Where(b => b.Id == book.Id)
                .FirstOrDefault();
            oldBook.Name = book.Name;
            oldBook.Description = book.Description;
            oldBook.Price = book.Price;
            oldBook.PageCount = book.PageCount;
            oldBook.EditionYear = book.EditionYear;
            oldBook.EditionNumber = book.EditionNumber;
            oldBook.Stock = book.Stock;
            oldBook.IsActive = book.IsActive;
            oldBook.IsHome = book.IsHome;
            oldBook.IsDeleted = book.IsDeleted;
            oldBook.AuthorId = book.AuthorId;
            oldBook.PublisherId = book.PublisherId;
            oldBook.Url = book.Url;
            oldBook.ModifiedDate = DateTime.Now;
            oldBook.BookCategories = book.BookCategories;
            oldBook.ImageUrl = book.ImageUrl;

            Context.Books.Update(oldBook);
            Context.SaveChanges();
        }

        public async Task UpdatePublisherOfBooks()
        {
            var books = await Context
                .Books
                .Where(b => b.PublisherId == null)
                .ToListAsync();
            foreach (var book in books)
            {
                book.PublisherId = 1;
            };
            Context.Books.UpdateRange(books);
            await Context.SaveChangesAsync();
        }

    }
}
