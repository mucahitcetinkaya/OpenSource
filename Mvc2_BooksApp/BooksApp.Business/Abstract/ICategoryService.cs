using BooksApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Business.Abstract
{
    public interface ICategoryService
    {
        #region Generic
        Task<Category> GetByIdAsync(int id);
        Task<List<Category>> GetAllAsync();
        Task CreateAsync(Category category);
        void Update(Category category);
        void Delete(Category category);
        #endregion
        #region Category
        Task<List<Category>> GetAllCategoriesAsync(bool isDeleted, bool? isActive=null);
        #endregion
    }
}
