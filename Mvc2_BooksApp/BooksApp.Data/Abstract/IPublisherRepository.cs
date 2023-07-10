using BooksApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Data.Abstract
{
    public interface IPublisherRepository : IGenericRepository<Publisher>
    {
        Task<List<Publisher>> GetAllPublishersAsync(bool isDeleted, bool? isActive = null);
    }
}
