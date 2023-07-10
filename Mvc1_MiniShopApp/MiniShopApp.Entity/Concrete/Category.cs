using MiniShopApp.Entity.Abstract;

namespace MiniShopApp.Entity.Concrete
{
    public class Category: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
