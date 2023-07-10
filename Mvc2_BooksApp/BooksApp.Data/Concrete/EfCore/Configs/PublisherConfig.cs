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
    public class PublisherConfig : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedDate).IsRequired();

            builder.Property(x => x.ModifiedDate).IsRequired();

            builder.Property(x => x.IsActive).IsRequired();

            builder.Property(x => x.IsDeleted).IsRequired();

            builder.Property(x => x.Url).IsRequired();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            builder.Property(x => x.City).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Country).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Phone).IsRequired().HasMaxLength(11);

            builder.HasData(
                new Publisher
                {
                    Id=1,
                    Name="Genel Yayınevi",
                    Country="",
                    City="",
                    Phone="",
                    Url="genel-yayinevi"
                },
                new Publisher
                {
                    Id = 11,
                    Name = "İthaki Yayınları",
                    Country = "Türkiye",
                    City = "İstanbul",
                    Phone = "02164785696",
                    Url="ithaki-yayinlari"
                },
                new Publisher
                {
                    Id = 2,
                    Name = "Alfa Yayınları",
                    Country = "Türkiye",
                    City = "İstanbul",
                    Phone = "02164785696",
                    Url="alfa-yayinlari"
                },
                new Publisher
                {
                    Id = 3,
                    Name = "Can Yayınları",
                    Country = "Türkiye",
                    City = "İstanbul",
                    Phone = "02164785696",
                    Url="can-yayinlari"
                },
                new Publisher
                {
                    Id = 4,
                    Name = "Kronik Yayınevi",
                    Country = "Türkiye",
                    City = "İstanbul",
                    Phone = "02164785696",
                    Url="kronik-yayinevi"
                },
                new Publisher
                {
                    Id = 5,
                    Name = "Domingo Yayınları",
                    Country = "Türkiye",
                    City = "İstanbul",
                    Phone = "02164785696",
                    Url="domingo-yayinlari"
                },
                new Publisher
                {
                    Id = 6,
                    Name = "Epsilon Yayınları",
                    Country = "Türkiye",
                    City = "İstanbul",
                    Phone = "02164785696",
                    Url="epsilon-yayinlari"
                },
                new Publisher
                {
                    Id = 7,
                    Name = "Nemesis",
                    Country = "Türkiye",
                    City = "İstanbul",
                    Phone = "02164785696",
                    Url="nemesis-kitap"
                },
                new Publisher
                {
                    Id = 8,
                    Name = "İş Bankası Kültür Yayınları",
                    Country = "Türkiye",
                    City = "İstanbul",
                    Phone = "02164785696",
                    Url="is-bankasi-kultur-yayinlari"
                },
                new Publisher
                {
                    Id = 9,
                    Name = "Yediveren Yayınları",
                    Country = "Türkiye",
                    City = "İstanbul",
                    Phone = "02164785696",
                    Url="yediveren-yayinlari"
                },
                new Publisher
                {
                    Id = 10,
                    Name = "April Yayıncılık",
                    Country = "Türkiye",
                    City = "İstanbul",
                    Phone = "02164785696",
                    Url="april-yayincilik"
                });
        }
    }
}
