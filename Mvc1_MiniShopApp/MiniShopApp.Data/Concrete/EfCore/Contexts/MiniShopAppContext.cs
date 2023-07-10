using Microsoft.EntityFrameworkCore;
using MiniShopApp.Data.Concrete.EfCore.Configs;
using MiniShopApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShopApp.Data.Concrete.EfCore.Contexts
{
    public class MiniShopAppContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MiniShopApp.db");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region ConfigYapılandırmasıKullanmadanÖncekiHali
            ////modelBuilder.Entity<ProductCategory>().HasNoKey();//Bu primary keye sahip olmayan bir tablo yaratılmasını sağlayacak.
            //Bu komut sayesinde ProductCategory entitysi kullanılarak oluşturulacak tabloda(ProductCategories) ProductId-CategoryId ikilisi PrimaryKey olarak tanımlanmış oldu. Yani bu ikilinin aynı değerleri taşıyan birden fazla satırda olması mümkün değil.

            ////Product Ayarları
            //modelBuilder.Entity<Product>().HasKey(p => p.Id);
            //modelBuilder.Entity<Product>().Property(p => p.Id).ValueGeneratedOnAdd();

            ////modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired();
            ////modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(100);
            //modelBuilder.Entity<Product>().Property(p => p.Name)
            //    .IsRequired()
            //    .HasMaxLength(100);
            #endregion

            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
