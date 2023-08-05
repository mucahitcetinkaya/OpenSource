using LessonWorld.Entity.Concrete;
using LessonWorld.Business.Abstract;
using LessonWorld.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonWorld.Business.Concrete
{
    public class CartManager :ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartManager(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task AddToCart(string userId, int lessonId, int quantity)
        {
            await _cartRepository.AddToCartAsync(userId, lessonId, quantity);
        }

        public  async Task DeleteAsync(string userId)
        {
            var cart = await GetCartByUserId(userId);
            _cartRepository.Delete(cart);
        }

        public Task<Cart> GetByIdAsync(int id)
        {
            return _cartRepository.GetByIdAsync(id);

        }

        public async Task<Cart> GetCartByUserId(string id)
        {
            return await _cartRepository.GetCartByUserId(id);

        }

        public async Task InitializeCart(string userId)
        {
            await _cartRepository.CreateAsync(new Cart { UserId = userId });
        }
    }
}
