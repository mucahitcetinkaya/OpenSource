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
    public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedDate).IsRequired();

            builder.Property(x => x.ModifiedDate).IsRequired();

            builder.Property(x => x.IsActive).IsRequired();

            builder.Property(x => x.IsDeleted).IsRequired();

            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);

            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);

            builder.Property(x => x.About).IsRequired().HasMaxLength(1000);

            builder.Property(x => x.Url).IsRequired();

            builder.Property(x => x.PhotoUrl).IsRequired();

            builder.HasData(
                 new Teacher
                 {
                     Id = 1,
                     FirstName = "Hamza",
                     LastName = "Hakan",
                     BirthOfYear = 1980,
                     PhotoUrl = "hamza-hakan.jpg",
                     Url = "hamza-hakan-1",
                     IsAlive = false,
                     About = "Spor Alanı Öğretmeni"
                 },
                new Teacher
                {
                    Id = 2,
                    FirstName = "Deniz",
                    LastName = "Keskin",
                    BirthOfYear = 1985,
                    PhotoUrl = "deniz-keskin.jpg",
                    Url = "deniz-keskin-2",
                    IsAlive = true,
                    About = "Spor Alanı Öğretmeni"
                },
                new Teacher
                {
                    Id = 3,
                    FirstName = "Sedef",
                    LastName = "Arak",
                    BirthOfYear = 1982,
                    PhotoUrl = "sedef-arak.jpg",
                    Url = "sedef-arak-3",
                    IsAlive = false,
                    About = "Sanat Alanı Öğretmeni"
                },
                new Teacher
                {
                    Id = 4,
                    FirstName = "Hakan",
                    LastName = "Tan",
                    BirthOfYear = 1990,
                    PhotoUrl = "hakan-tan.jpg",
                    Url = "hakan-tan-4",
                    IsAlive = false,
                    About = "Sanat Alanı Öğretmeni"
                },
                new Teacher
                {
                    Id = 5,
                    FirstName = "Aysun",
                    LastName = "Yılmaz",
                    BirthOfYear = 1982,
                    PhotoUrl = "aysun-yilmaz.jpg",
                    Url = "aysun-yilmaz-5",
                    IsAlive = true,
                    About = "Sözel Alan Öğretmeni"
                },
                new Teacher
                {
                    Id = 6,
                    FirstName = "Mine",
                    LastName = "Kar",
                    BirthOfYear = 1987,
                    PhotoUrl = "mine-kar.jpg",
                    Url = "mine-kar-6",
                    IsAlive = false,
                    About = "Sözel Alan Öğretmeni"
                },
                new Teacher
                {
                    Id = 7,
                    FirstName = "Mehmet",
                    LastName = "Dar",
                    BirthOfYear = 1975,
                    PhotoUrl = "mehmet-dar.jpg",
                    Url = "mehmet-dar-7",
                    IsAlive = false,
                    About = "Sayısal Alan Öğretmeni "
                },
                new Teacher
                {
                    Id = 8,
                    FirstName = "Osman",
                    LastName = "Hak",
                    BirthOfYear = 1980,
                    PhotoUrl = "osman-hak.jpg",
                    Url = "osman-hak-8",
                    IsAlive = false,
                    About = "Sayısal Alan Öğretmeni "
                },
                new Teacher
                {
                    Id = 9,
                    FirstName = "Kayahan",
                    LastName = "Keten",
                    BirthOfYear = 1982,
                    PhotoUrl = "kayahan-keten.jpg",
                    Url = "kayahan-keten-9",
                    IsAlive = true,
                    About = "Enstürman Alanı Öğretmeni"
                },
                new Teacher
                {
                    Id = 10,
                    FirstName = "Ela",
                    LastName = "Kara",
                    BirthOfYear = 1992,
                    PhotoUrl = "ela-kara.jpg",
                    Url = "ela-kara-10",
                    IsAlive = false,
                    About = " Enstürman Alanı Öğretmeni "
                });



        }

    }
}
