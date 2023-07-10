using MiniShopApp.Entity.Concrete;

namespace MiniShopApp.Mvc.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Name { get; set; }
        public string Properties { get; set; }
        public decimal Price { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public List<Category> Categories { get; set; }
    }
}