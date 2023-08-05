using LessonWorld.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonWorld.Data.Concrete.EfCore.Configs
{
    public class SchoolConfig : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
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
              new School
              {
                  Id = 1,
                  Name = "Beşiktaş Koleji",
                  Country = "Türkiye",
                  City = "İstanbul",
                  Phone = "02122321933",
                  Url = "besiktas-koleji",
                 
              },
              new School
              {
                  Id = 2,
                  Name = "Kartal Akademi",
                  Country = "Türkiye",
                  City = "İstanbul",
                  Phone = "02164785696",
                  Url = "kartal-akademi",
                  

              });
        }
    }
}
