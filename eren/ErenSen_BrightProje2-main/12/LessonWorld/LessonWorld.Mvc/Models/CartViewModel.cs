using LessonWorld.Data.Concrete.EfCore.Configs;
using System.ComponentModel.DataAnnotations;

namespace LessonWorld.Mvc.Models
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
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public string LessonUrl { get; set; }
        public string LessonImageUrl { get; set; }
        public decimal? Price { get; set; }
        [Required(ErrorMessage ="Boş bırakılmalalıdır.")]
        public int Quantity { get; set; }
    }
}
