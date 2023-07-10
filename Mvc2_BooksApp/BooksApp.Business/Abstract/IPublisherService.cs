using BooksApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Business.Abstract
{
    public interface IPublisherService
    {
        #region Generic
        Task<Publisher> GetByIdAsync(int? id);
        Task<List<Publisher>> GetAllAsync();
        Task CreateAsync(Publisher publisher);
        void Update(Publisher publisher);
        void Delete(Publisher publisher);
        #endregion
        #region Publisher
        Task<List<Publisher>> GetAllPublishersAsync(bool isDeleted, bool? isActive = null);
        #endregion
    }
}
