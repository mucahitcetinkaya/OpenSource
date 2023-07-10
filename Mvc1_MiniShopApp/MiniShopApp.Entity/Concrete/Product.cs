using MiniShopApp.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShopApp.Entity.Concrete
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Properties { get; set; }
        public decimal Price { get; set; }
        public bool IsHome { get; set; }
        public string Url { get; set; }//Product'ın url bilgisi, örn: i-phone-13-15789
        public string ImageUrl { get; set; }//Resim'in url bilgisi, örn: 35SDFAS324sd.png
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
