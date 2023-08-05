﻿using LessonWorld.Business.Abstract;
using LessonWorld.Data.Abstract;
using LessonWorld.Entity.Concrete;
using LessonWorld.Entity.Concrete.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonWorld.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task CreateAsync(Order order)
        {
            await _orderRepository.CreateAsync(order);
        }

        public async Task<List<Order>> GetAllOrdersAsync(string userId = null, bool dateSort = false, OrderStatus? orderStatus = null)
        {
            return await _orderRepository.GetAllOrdersAsync(userId, dateSort, orderStatus);
        }

        public async Task<string> GetTotalAsync(int action)
        {
            return await _orderRepository.GetTotalAsync(action);
        }
    }
}
