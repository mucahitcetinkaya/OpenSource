﻿using BooksApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Business.Abstract
{
    public interface ICartItemService
    {
        Task ChangeQuantityAsync(int cartItemId, int quantity);
        void ClearCart(int cartId);
        void Delete(CartItem item);
        Task<CartItem> GetByIdAsync(int cartItemId);
    }
}
