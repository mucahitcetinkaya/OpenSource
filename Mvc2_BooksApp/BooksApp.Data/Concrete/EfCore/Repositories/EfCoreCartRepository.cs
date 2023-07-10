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
    public class EfCoreCartRepository : EfCoreGenericRepository<Cart>, ICartRepository
    {
        public EfCoreCartRepository(BooksAppContext _appContext) : base(_appContext)
        {

        }
        BooksAppContext AppContext
        {
            get { return _dbContext as BooksAppContext; }
        }

        public async Task AddToCartAsync(string userId, int bookId, int quantity)
        {
            var cart = await GetCartByUserId(userId);
            if (cart != null)
            {
                var index = cart.CartItems.FindIndex(ci => ci.BookId == bookId);
                if (index < 0)//Kitap daha önceden sepete eklenmemişse
                {
                    cart.CartItems.Add(new CartItem
                    {
                        BookId = bookId,
                        CartId = cart.Id,
                        Quantity = quantity
                    });
                }
                else //Eğer kitap daha önceden sepete eklenmişse -- adedi arttıracağız
                {
                    cart.CartItems[index].Quantity += quantity;
                }

                AppContext.Carts.Update(cart);
                await AppContext.SaveChangesAsync();
            }
        }

        public async Task<Cart> GetCartByUserId(string userId)
        {
            var result = await AppContext
                .Carts
                .Where(c => c.UserId == userId)
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Book)
                .FirstOrDefaultAsync();
            return result;
        }
    }
}
