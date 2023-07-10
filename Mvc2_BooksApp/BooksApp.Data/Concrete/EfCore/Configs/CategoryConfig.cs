using BooksApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Data.Concrete.EfCore.Configs
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedDate).IsRequired();

            builder.Property(x => x.ModifiedDate).IsRequired();

            builder.Property(x => x.IsActive).IsRequired();

            builder.Property(x => x.IsDeleted).IsRequired();

            builder.Property(x => x.Url).IsRequired();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            builder.Property(x => x.Description).IsRequired().HasMaxLength(1000);

            builder.HasData(
                new Category
                {
                    Id=1,
                    Name="Genel",
                    Description="Genel kategorisine giren ve kategorisiz kalan kitaplar",
                    Url="Genel"
                },
                new Category
                {
                    Id=2,
                    Name="Bilim Kurgu",
                    Description="Bilim Kurgu Kitapları",
                    Url="bilim-kurgu"
                },
                new Category
                {
                    Id = 3,
                    Name = "Bilim ve Mühendislik",
                    Description = "Bilim ve Mühendislik Kitapları",
                    Url = "bilim-ve-muhendislik"
                },
                new Category
                {
                    Id = 4,
                    Name = "Distopya",
                    Description = "Distopya Kitapları",
                    Url = "distopya"
                },
                new Category
                {
                    Id = 5,
                    Name = "Dünya Tarihi",
                    Description = "Dünya Tarihi Kitapları",
                    Url = "dunya-tarihi"
                },
                new Category
                {
                    Id = 6,
                    Name = "Edebiyat",
                    Description = "Edebiyat Kitapları",
                    Url = "edebiyat"
                },
                new Category
                {
                    Id = 7,
                    Name = "Fizik",
                    Description = "Fizik Kitapları",
                    Url = "fizik"
                },
                new Category
                {
                    Id = 8,
                    Name = "İnsan ve Toplum",
                    Description = "İnsan ve Toplum Kitapları",
                    Url = "insan-ve-toplum"
                },
                new Category
                {
                    Id = 9,
                    Name = "Kişisel Gelişim",
                    Description = "Kişisel Kitapları",
                    Url = "kisisel-gelisim"
                },
                new Category
                {
                    Id = 10,
                    Name = "Popüler Bilim",
                    Description = "Popüler Bilim Kitapları",
                    Url = "populer-bilim"
                },
                new Category
                {
                    Id = 11,
                    Name = "Roman",
                    Description = "Romanlar",
                    Url = "roman"
                },
                new Category
                {
                    Id = 12,
                    Name = "Rus Edebiyatı",
                    Description = "Rus Edebiyatı Kitapları",
                    Url = "rus-edebiyati"
                },
                new Category
                {
                    Id = 13,
                    Name = "Söyleşi",
                    Description = "Söyleşi Kitapları",
                    Url = "soylesi"
                },
                new Category
                {
                    Id = 14,
                    Name = "Tarih",
                    Description = "Tarih Kitapları",
                    Url = "tarih"
                },
                new Category
                {
                    Id = 15,
                    Name = "Türkiye Tarihi",
                    Description = "Türkiye Tarihi Kitapları",
                    Url = "turkiye-tarihi"
                });
        }
    }
}
