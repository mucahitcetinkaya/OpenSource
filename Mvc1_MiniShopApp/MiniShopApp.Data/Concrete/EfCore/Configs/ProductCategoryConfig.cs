using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniShopApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShopApp.Data.Concrete.EfCore.Configs
{
    public class ProductCategoryConfig : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(pc => new { pc.ProductId, pc.CategoryId });
            builder.ToTable("ProductCategories");

            builder.HasData(
                new ProductCategory { ProductId = 1, CategoryId = 1 },
                new ProductCategory { ProductId = 1, CategoryId = 3 },

                new ProductCategory { ProductId = 2, CategoryId = 1 },
                new ProductCategory { ProductId = 2, CategoryId = 3 },

                new ProductCategory { ProductId = 3, CategoryId = 1 },
                new ProductCategory { ProductId = 3, CategoryId = 3 },

                new ProductCategory { ProductId = 4, CategoryId = 1 },
                new ProductCategory { ProductId = 4, CategoryId = 3 },

                new ProductCategory { ProductId = 5, CategoryId = 3 },
                new ProductCategory { ProductId = 5, CategoryId = 4 },

                new ProductCategory { ProductId = 6, CategoryId = 3 },
                new ProductCategory { ProductId = 6, CategoryId = 4 },

                new ProductCategory { ProductId = 7, CategoryId = 3 },
                new ProductCategory { ProductId = 7, CategoryId = 4 },

                new ProductCategory { ProductId = 8, CategoryId = 2 },
                new ProductCategory { ProductId = 8, CategoryId = 4 },

                new ProductCategory { ProductId = 9, CategoryId = 2 },
                new ProductCategory { ProductId = 9, CategoryId = 4 },

                new ProductCategory { ProductId = 10, CategoryId = 2 },
                new ProductCategory { ProductId = 10, CategoryId = 4 }

                );
        }
    }
}
