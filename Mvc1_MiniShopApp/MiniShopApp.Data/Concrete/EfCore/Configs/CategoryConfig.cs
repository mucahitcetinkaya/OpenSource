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
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);//PrimaryKey
            builder.Property(c => c.Id).ValueGeneratedOnAdd();//Identity
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);//Zorunlu olması ve Maksimum karakter sayısı
            builder.Property(c => c.Description).IsRequired().HasMaxLength(500);
            builder.Property(c => c.Url).IsRequired().HasMaxLength(500);
            builder.ToTable("Categories");

            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Telefon",
                    Description = "Telefonlar burada",
                    Url = "telefon"
                },
                new Category
                {
                    Id = 2,
                    Name = "Bilgisayar",
                    Description = "Bilgisayarlar burada",
                    Url = "bilgisayar"
                },
                new Category
                {
                    Id = 3,
                    Name = "Elektronik",
                    Description = "Elektronik ürünler burada",
                    Url = "elektronik"
                },
                new Category
                {
                    Id = 4,
                    Name = "Beyaz Eşya",
                    Description = "Beyaz eşyalar burada",
                    Url = "beyaz-esya"
                });
        }
    }
}
