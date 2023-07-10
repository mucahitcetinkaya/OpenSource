using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApp.MVC.Models;

namespace BooksApp.MVC.Areas.Admin.Models
{
    public class AdminDashboardViewModel
    {
        public decimal? TotalSalesAmount { get; set; }
        public int TotalSalesCount { get; set; }
        public int TotalBookSalesCount { get; set; }
        public List<OrderViewModel> ReceivedOrders { get; set; }
        public List<OrderViewModel> PreparingOrders { get; set; }
        public List<OrderViewModel> SentOrders { get; set; }
        public List<OrderViewModel> DeliveredOrders { get; set; }
    }
}