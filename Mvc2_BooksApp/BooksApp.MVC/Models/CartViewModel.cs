using BooksApp.Data.Concrete.EfCore.Configs;
using System.ComponentModel.DataAnnotations;

namespace BooksApp.MVC.Models
{
    public class CartViewModel
    {
        public int CartId { get; set; }
        public List<CartItemViewModel> CartItems { get; set; }
        public decimal? TotalPrice()
        {
            return CartItems.Sum(ci=>ci.Price * ci.Quantity);
        }
    }
    public class CartItemViewModel
    {
        public int CartItemId { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookUrl { get; set; }
        public string BookImageUrl { get; set; }
        public decimal? Price { get; set; }
        [Required(ErrorMessage ="Boş bırakılmalalıdır.")]
        public int Quantity { get; set; }
    }
}
