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
    public class LessonConfig : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
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

            builder.Property(x => x.ImageUrl).IsRequired();

            builder.Property(x => x.Price).IsRequired();

            builder.Property(x => x.IsHome).IsRequired();

            builder.HasOne(x => x.School).WithMany(x => x.Lessons).HasForeignKey(x => x.SchoolId).OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Teacher).WithMany(x => x.Lessons).HasForeignKey(x => x.TeacherId).OnDelete(DeleteBehavior.SetNull);


            builder.HasData(
            new Lesson
            {
                Id = 1,
                Name = "Basketbol",
                Description = "Basketbol  alanında gelişim eğitimi",
                Url = "basketbol-1",
                ImageUrl = "basketbol.jpg",
                Price = 100,
                IsHome = false,
                TeacherId = 1,
                SchoolId = 1,
            },
            new Lesson
            {
                Id = 2,
                Name = "Futbol",
                Description = "Futbol  alanında gelişim eğitimi",
                Url = "Futbol-2",
                ImageUrl = "futbol.jpg",
                Price = 100,
                IsHome = false,
                TeacherId = 2,
                SchoolId = 1,

            },
            new Lesson
            {
                Id = 3,
                Name = "Voleybol",
                Description = "Voleybol  alanında gelişim eğitimi",
                Url = "voleybol-3",
                ImageUrl = "voleybol.jpg",
                Price = 100,
                IsHome = false,
                TeacherId = 1,
                SchoolId = 1,

            },
            new Lesson
            {
                Id = 4,
                Name = "Yüzme",
                Description = "Yüzme  alanında gelişim eğitimi",
                Url = "yuzme-4",
                ImageUrl = "yuzme.jpg",
                Price = 100,
                IsHome = false,
                TeacherId = 2,
                SchoolId = 1,

            },
            new Lesson
            {
                Id = 5,
                Name = "Koşu",
                Description = "Koşu alanında gelişim eğitimi",
                Url = "kosu-5",
                ImageUrl = "kosu.jpg",
                Price = 100,
                IsHome = false,
                TeacherId = 1,
                SchoolId = 1,

            },
            new Lesson
            {
                Id = 6,
                Name = "Heykel Traş",
                Description = "Heykel Traş  alanında gelişim eğitimi",
                Url = "tras-6",
                ImageUrl = "tras.jpg",
                Price = 100,
                IsHome = false,
                TeacherId = 3,
                SchoolId = 1,

            },
            new Lesson
            {
                Id = 7,
                Name = "Resim",
                Description = "Resim  alanında gelişim eğitimi",
                Url = "resim-7",
                ImageUrl = "resim.jpg",
                Price = 100,
                IsHome = false,
                TeacherId = 3,
                SchoolId = 1,

            },
            new Lesson
            {
                Id = 8,
                Name = "Temel Tasarım",
                Description = "Temel Tasarım  alanında gelişim eğitimi",
                Url = "temel-tasarım-8",
                ImageUrl = "tras.jpg",
                Price = 100,
                IsHome = false,
                TeacherId = 3,
                SchoolId = 1,

            },
            new Lesson
            {
                Id = 9,
                Name = "Mozaik",
                Description = "Mozaik  alanında gelişim eğitimi",
                Url = "mozaik-9",
                ImageUrl = "mozaik.jpg",
                Price = 100,
                IsHome = false,
                TeacherId = 4,
                SchoolId = 1,

            },
            new Lesson
            {
                Id = 10,
                Name = "Seramik",
                Description = "Seramik  alanında gelişim eğitimi",
                Url = "seramik-10",
                ImageUrl = "seramik.jpg",
                Price = 100,
                IsHome = false,
                TeacherId = 4,
                SchoolId = 1,

            },
            new Lesson
            {
                Id = 11,
                Name = "Türkçe",
                Description = "Türkçe  alanında gelişim eğitimi",
                Url = "turkce-11",
                ImageUrl = "turkce.jpg",
                Price = 100,
                IsHome = false,
                TeacherId = 5,
                SchoolId = 1,

            },
            new Lesson
            {
                Id = 12,
                Name = "Edebiyat",
                Description = "Edebiyat  alanında gelişim eğitimi",
                Url = "edebiyat-12",
                ImageUrl = "edebiyat.jpg",
                Price = 100,
                IsHome = false,
                TeacherId = 5,
                SchoolId = 1,

            },
            new Lesson
            {
                Id = 13,
                Name = "Dil Anlatım",
                Description = "Dil Anlatım  alanında gelişim eğitimi",
                Url = "dil-analatim-13",
                ImageUrl = "dil-anlatim.jpg",
                Price = 100,
                IsHome = false,
                TeacherId = 5,
                SchoolId = 1,

            },
            new Lesson
            {
                Id = 14,
                Name = "Tarih",
                Description = "Tarih alanında gelişim eğitimi",
                Url = "tarih-14",
                ImageUrl = "tarih.jpg",
                Price = 100,
                IsHome = false,
                TeacherId = 6,
                SchoolId = 1,

            },
            new Lesson
            {
                Id = 15,
                Name = "Felsefe",
                Description = "Felsefe  alanında gelişim eğitimi",
                Url = "felsefe-15",
                ImageUrl = "felsefe.jpg",
                Price = 100,
                IsHome = false,
                TeacherId = 6,
                SchoolId = 1,

            },
            new Lesson
            {
                Id = 16,
                Name = "Matematik",
                Description = "Matematik  alanında gelişim eğitimi",
                Url = "matematik-16",
                ImageUrl = "matematik.jpg",
                Price = 100,
                IsHome = false,
                TeacherId = 7,
                SchoolId = 1,

            },
            new Lesson
            {
                Id = 17,
                Name = "Geometri",
                Description = "Geometri  alanında gelişim eğitimi",
                Url = "geometri-17",
                ImageUrl = "geometri.jpg",
                Price = 100,
                IsHome = false,
                TeacherId = 7,
                SchoolId = 1,

            },
            new Lesson
            {
                Id = 18,
                Name = "Fizik",
                Description = "Fizik  alanında gelişim eğitimi",
                Url = "fizik-18",
                ImageUrl = "fizik.jpg",
                Price = 100,
                IsHome = false,
                TeacherId = 7,
                SchoolId = 1,

            },
            new Lesson
            {
                Id = 19,
                Name = "Kimya",
                Description = "Kimya  alanında gelişim eğitimi",
                Url = "kimya-19",
                ImageUrl = "kimya.jpg",
                Price = 100,
                IsHome = false,
                TeacherId = 8,
                SchoolId = 1,

            },
            new Lesson
            {
                Id = 20,
                Name = "Biyoloji",
                Description = "Biyoloji  alanında gelişim eğitimi",
                Url = "biyoloji-20",
                ImageUrl = "Biyoloji.jpg",
                Price = 100,
                IsHome = false,
                TeacherId = 8,
                SchoolId = 1,

            },
            new Lesson
            {
                Id = 21,
                Name = "Gitar",
                Description = "Geometri  alanında gelişim eğitimi",
                Url = "gitar-21",
                ImageUrl = "gitar.jpg",
                Price = 100,
                IsHome = false,
                TeacherId = 9,
                SchoolId = 1,

            },
            new Lesson
            {
                Id = 22,
                Name = "Saz",
                Description = "Saz  alanında gelişim eğitimi",
                Url = "saz-22",
                ImageUrl = "saz.jpg",
                Price = 100,
                IsHome = false,
                TeacherId = 9,
                SchoolId = 1,

            },
            new Lesson
            {
                Id = 23,
                Name = "Keman",
                Description = "Keman  alanında gelişim eğitimi",
                Url = "keman-23",
                ImageUrl = "keman.jpg",
                Price = 100,
                IsHome = false,
                TeacherId = 9,
                SchoolId = 1,

            },
            new Lesson
            {
                Id = 24,
                Name = "Piyano",
                Description = "Piyano  alanında gelişim eğitimi",
                Url = "piyano-24",
                ImageUrl = "piyano.jpg",
                Price = 100,
                IsHome = false,
                TeacherId = 10,
                SchoolId = 1,

            },
            new Lesson
            {
                Id = 25,
                Name = "Saksafon",
                Description = "Saksafon  alanında gelişim eğitimi",
                Url = "saksafon-25",
                ImageUrl = "saksafon.jpg",
                Price = 100,
                IsHome = false,
                TeacherId = 10,
                SchoolId = 1,

            });

        }

    }
}

