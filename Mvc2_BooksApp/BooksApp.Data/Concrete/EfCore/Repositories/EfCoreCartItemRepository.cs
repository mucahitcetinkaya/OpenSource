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
    public class EfCoreCartItemRepository : EfCoreGenericRepository<CartItem>, ICartItemRepository
    {
        public EfCoreCartItemRepository(BooksAppContext _appContext):base(_appContext)
        {
            
        }
        BooksAppContext AppContext
        {
            get { return _dbContext as BooksAppContext; }
        }
        public async Task ChangeQuantityAsync(CartItem item, int quantity)
        {
            item.Quantity = quantity;
            AppContext.CartItems.Update(item);
            await AppContext.SaveChangesAsync();
        }

        public void ClearCart(int cartId)
        {
            AppContext
                .CartItems
                .Where(ci => ci.CartId == cartId)
                .ExecuteDelete();
        }
    }
}
