using BooksApp.Data.Abstract;
using BooksApp.Data.Concrete.EfCore.Contexts;
using BooksApp.Entity.Concrete;
using BooksApp.Entity.Concrete.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Data.Concrete.EfCore.Repositories
{
    public class EfCoreOrderRepository : EfCoreGenericRepository<Order>, IOrderRepository
    {
        public EfCoreOrderRepository(BooksAppContext _appContext) : base(_appContext)
        {

        }
        BooksAppContext AppContext
        {
            get { return _dbContext as BooksAppContext; }
        }

        public async Task<List<Order>> GetAllOrdersAsync(string userId = null, bool dateSort = false, OrderStatus? orderStatus = null)
        {
            var result = AppContext
                .Orders
                .AsQueryable();
            if (!String.IsNullOrEmpty(userId))
            {
                result = result.Where(o => o.UserId == userId);
            }
            if (dateSort)
            {
                result = result.OrderByDescending(o => o.OrderDate);
            }
            else
            {
                result = result.OrderBy(o => o.OrderDate);
            }
            if (orderStatus != null)
            {
                result = result.Where(o => o.OrderStatus == orderStatus);
            }
            result = result
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Book);
            return await result.ToListAsync();
        }

        public async Task<string> GetTotalAsync(int action)
        {
            var orders = await AppContext
                .Orders
                .Include(o => o.OrderItems)
                .ToListAsync();
            decimal? total = 0;
            int count = 0;
            int countBooks = 0;
            string result = "";
            foreach (var order in orders)
            {
                foreach (var item in order.OrderItems)
                {
                    if (action == 0)
                    {
                        total += item.Quantity * item.Price;
                        result = total.ToString();
                    }
                    else if (action == 1)
                    {
                        count++;
                        result = count.ToString();
                    }
                    else
                    {
                        countBooks += item.Quantity;
                        result = countBooks.ToString();
                    }

                }
            }
            return result;


            //var result = await AppContext
            //    .Orders
            //    .Include(o => o.OrderItems)
            //    .Select(o => o.OrderItems.Sum(oi => Convert.ToInt32(oi.Quantity) * Convert.ToInt32(oi.Price)))
            //    .SingleOrDefaultAsync();
            //return result;
        }
    }
}
