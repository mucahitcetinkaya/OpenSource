using LessonWorld.Entity.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LessonWorld.Data.Concrete.EfCore.Configs
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
                    Id = 1,
                    Name = "Spor",
                    Description = "Spor Dersleri Basketbol,Futbol,Volaybol,Yüzme,Koşu",
                    Url = "spor-dersleri"
                },
                new Category
                {
                    Id = 2,
                    Name = "Sanat",
                    Description = "Sanat Derleri,Heykel Traş,Resim,Mozaik,Seramik,Temel Tasarım",
                    Url = "sanat-dersleri"

                },
                new Category
                {
                    Id = 3,
                    Name = "Sözel",
                    Description = "Sözel Dersler Türkçe,Tarih,Felsefe,Edebiyat,Dil Anlatım",
                    Url = "sozel-dersleri"
                },
                new Category
                {
                    Id = 4,
                    Name = "Sayısal",
                    Description = "Sayısal Dersler Matematik,Fizik,Kimya Biyoloji,Geometri",
                    Url = "sayisal-dersleri"
                },
                new Category
                {
                    Id = 5,
                    Name = "Enstürman",
                    Description = "Enstürman Dersleri Gitar,Keman,Saz,Piyano,Saksafon",
                    Url = "enstürman-dersleri"
                });


                    

        }
    }
}
