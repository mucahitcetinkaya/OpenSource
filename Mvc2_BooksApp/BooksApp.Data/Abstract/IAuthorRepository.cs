using BooksApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Data.Abstract
{
    public interface IAuthorRepository:IGenericRepository<Author>
    {
        Task<List<Author>> GetAllAuthorsAsync(bool isDeleted, bool? isActive = null);
        Task CreateWithUrl(Author author);
    }
}
