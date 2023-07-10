using BooksApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Business.Abstract
{
    public interface IAuthorService
    {
        #region Generic
        Task<Author> GetByIdAsync(int? id);
        Task<List<Author>> GetAllAsync();
        Task CreateAsync(Author author);
        void Update(Author author);
        void Delete(Author author);
        #endregion
        #region Author
        Task<List<Author>> GetAllAuthorsAsync(bool isDeleted, bool? isActive = null);
        Task CreateWithUrl(Author author);
        #endregion
    }
}
