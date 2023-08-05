using LessonWorld.Data.Abstract;
using LessonWorld.Data.Concrete.EfCore.Contexts;
using LessonWorld.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonWorld.Data.Concrete.EfCore.Repositories
{
    public class EfCoreCartRepository : EfCoreGenericRepository<Cart>, ICartRepository
    {
        public EfCoreCartRepository(LessonWorldContext _appContext) : base(_appContext)
        {

        }
        LessonWorldContext AppContext
        {
            get { return _dbContext as LessonWorldContext; }
        }

        public async Task AddToCartAsync(string userId, int lessonId, int quantity)
        {
            var cart = await GetCartByUserId(userId);
            if (cart != null)
            {
                var index = cart.CartItems.FindIndex(ci => ci.LessonId == lessonId);
                if (index < 0)
                {
                    cart.CartItems.Add(new CartItem
                    {
                        LessonId = lessonId,
                        CartId = cart.Id,
                        Quantity = quantity
                    });
                }
                else 
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
                .ThenInclude(ci => ci.Lesson)
                .FirstOrDefaultAsync();
            return result;
        }
    }
}
