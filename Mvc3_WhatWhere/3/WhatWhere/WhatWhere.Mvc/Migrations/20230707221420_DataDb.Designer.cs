﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WhatWhere.Mvc.Context;

#nullable disable

namespace WhatWhere.Mvc.Migrations
{
    [DbContext(typeof(WhatWhereContext))]
    [Migration("20230707221420_DataDb")]
    partial class DataDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("WhatWhere.Mvc.Models.Boss", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BirthOfYear")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MailAdress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Bosses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthOfYear = 1990,
                            FirstName = "Ahmet",
                            Gender = "Male",
                            LastName = "Yılmaz",
                            MailAdress = "ahmet@example.com",
                            PhoneNumber = "1234567890",
                            Url = "ahmet-yilmaz.com"
                        },
                        new
                        {
                            Id = 2,
                            BirthOfYear = 1985,
                            FirstName = "Mehmet",
                            Gender = "Male",
                            LastName = "Kaya",
                            MailAdress = "mehmet@example.com",
                            PhoneNumber = "1234567890",
                            Url = "mehmet-kaya.com"
                        },
                        new
                        {
                            Id = 3,
                            BirthOfYear = 1992,
                            FirstName = "Ayşe",
                            Gender = "Female",
                            LastName = "Demir",
                            MailAdress = "ayse@example.com",
                            PhoneNumber = "1234567890",
                            Url = "ayse-demir.com"
                        },
                        new
                        {
                            Id = 4,
                            BirthOfYear = 1988,
                            FirstName = "Fatma",
                            Gender = "Female",
                            LastName = "Yıldırım",
                            MailAdress = "fatma@example.com",
                            PhoneNumber = "1234567890",
                            Url = "fatma-yildirim.com"
                        },
                        new
                        {
                            Id = 5,
                            BirthOfYear = 1995,
                            FirstName = "Ali",
                            Gender = "Male",
                            LastName = "Öztürk",
                            MailAdress = "ali@example.com",
                            PhoneNumber = "1234567890",
                            Url = "ali-ozturk.com"
                        },
                        new
                        {
                            Id = 6,
                            BirthOfYear = 1991,
                            FirstName = "Zeynep",
                            Gender = "Female",
                            LastName = "Aktaş",
                            MailAdress = "zeynep@example.com",
                            PhoneNumber = "1234567890",
                            Url = "zeynep-aktas.com"
                        },
                        new
                        {
                            Id = 7,
                            BirthOfYear = 1987,
                            FirstName = "Hakan",
                            Gender = "Male",
                            LastName = "Koç",
                            MailAdress = "hakan@example.com",
                            PhoneNumber = "1234567890",
                            Url = "hakan-koc.com"
                        },
                        new
                        {
                            Id = 8,
                            BirthOfYear = 1994,
                            FirstName = "Selin",
                            Gender = "Female",
                            LastName = "Can",
                            MailAdress = "selin@example.com",
                            PhoneNumber = "1234567890",
                            Url = "selin-can.com"
                        },
                        new
                        {
                            Id = 9,
                            BirthOfYear = 1989,
                            FirstName = "Murat",
                            Gender = "Male",
                            LastName = "Şahin",
                            MailAdress = "murat@example.com",
                            PhoneNumber = "1234567890",
                            Url = "murat-sahin.com"
                        },
                        new
                        {
                            Id = 10,
                            BirthOfYear = 1993,
                            FirstName = "Deniz",
                            Gender = "Female",
                            LastName = "Arslan",
                            MailAdress = "deniz@example.com",
                            PhoneNumber = "1234567890",
                            Url = "deniz-arslan.com"
                        });
                });

            modelBuilder.Entity("WhatWhere.Mvc.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Kasap Kategorisi",
                            Name = "Kasap"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Eczane Kategorisi",
                            Name = "Eczane"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Kırtasiye Kategorisi",
                            Name = "Kırtasiye"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Terzi Kategorisi",
                            Name = "Terzi"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Dişçi Kategorisi",
                            Name = "Dişçi"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Kiralık Katil Kategorisi",
                            Name = "Kiralık Katil"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Gym Kategorisi",
                            Name = "Gym"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Mantıcı Kategorisi",
                            Name = "Mantıcı"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Futbol Sahası Kategorisi",
                            Name = "Futbol Sahası"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Lostra Kategorisi",
                            Name = "Lostra"
                        },
                        new
                        {
                            Id = 11,
                            Description = "Bakkal Kategorisi",
                            Name = "Bakkal"
                        },
                        new
                        {
                            Id = 12,
                            Description = "Restoran Kategorisi",
                            Name = "Restoran"
                        },
                        new
                        {
                            Id = 13,
                            Description = "Kafe Kategorisi",
                            Name = "Kafe"
                        },
                        new
                        {
                            Id = 14,
                            Description = "Butik Kategorisi",
                            Name = "Butik"
                        },
                        new
                        {
                            Id = 15,
                            Description = "Optik Kategorisi",
                            Name = "Optik"
                        },
                        new
                        {
                            Id = 16,
                            Description = "Mobilya Mağazası Kategorisi",
                            Name = "Mobilya Mağazası"
                        },
                        new
                        {
                            Id = 17,
                            Description = "Oyuncakçı Kategorisi",
                            Name = "Oyuncakçı"
                        },
                        new
                        {
                            Id = 18,
                            Description = "Elektronik Mağaza Kategorisi",
                            Name = "Elektronik Mağaza"
                        },
                        new
                        {
                            Id = 19,
                            Description = "Çiçekçi Kategorisi",
                            Name = "Çiçekçi"
                        },
                        new
                        {
                            Id = 20,
                            Description = "Kitapçı Kategorisi",
                            Name = "Kitapçı"
                        },
                        new
                        {
                            Id = 21,
                            Description = "Genel Kategorisi",
                            Name = "Genel"
                        });
                });

            modelBuilder.Entity("WhatWhere.Mvc.Models.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsHome")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MailAdress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Shops");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "İstiklal Caddesi, Beyoğlu, Türkiye",
                            City = "İstanbul",
                            Country = "Türkiye",
                            CreatedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(2944),
                            Description = "Lezzetli et ürünleriyle hizmet veren kasap dükkanı.",
                            ImageUrl = "kasap.jpg",
                            IsActive = false,
                            IsDeleted = false,
                            IsHome = false,
                            MailAdress = "info@kasap.com",
                            ModifiedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(2957),
                            Name = "Özgün Kasap",
                            PhoneNumber = "1234567890",
                            Town = "Beyoğlu",
                            Url = "www.kasap.com"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Bağdat Caddesi, Kadıköy, Türkiye",
                            City = "İstanbul",
                            Country = "Türkiye",
                            CreatedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(2963),
                            Description = "Sağlık ürünleri ve ilaçların bulunduğu eczane.",
                            ImageUrl = "eczane.jpg",
                            IsActive = true,
                            IsDeleted = false,
                            IsHome = true,
                            MailAdress = "info@eczane.com",
                            ModifiedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(2964),
                            Name = "Namık Eczanesi",
                            PhoneNumber = "1234567890",
                            Town = "Kadıköy",
                            Url = "www.eczane.com"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Nişantaşı, Şişli, Türkiye",
                            City = "İstanbul",
                            Country = "Türkiye",
                            CreatedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(2967),
                            Description = "Kalemlerden defterlere, kırtasiye malzemelerinin satıldığı dükkân.",
                            ImageUrl = "kirtasiye.jpg",
                            IsActive = false,
                            IsDeleted = false,
                            IsHome = false,
                            MailAdress = "info@kirtasiye.com",
                            ModifiedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(2967),
                            Name = "Ozan Kırtasiyesi",
                            PhoneNumber = "1234567890",
                            Town = "Şişli",
                            Url = "www.kirtasiye.com"
                        },
                        new
                        {
                            Id = 4,
                            Address = "Levent Mahallesi, Beşiktaş, Türkiye",
                            City = "İstanbul",
                            Country = "Türkiye",
                            CreatedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(2970),
                            Description = "Kıyafet tamiratı ve dikimi yapan terzi dükkânı.",
                            ImageUrl = "terzi.jpg",
                            IsActive = true,
                            IsDeleted = false,
                            IsHome = true,
                            MailAdress = "info@terzi.com",
                            ModifiedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(2970),
                            Name = "Neşe Terzi",
                            PhoneNumber = "1234567890",
                            Town = "Beşiktaş",
                            Url = "www.terzi.com"
                        },
                        new
                        {
                            Id = 5,
                            Address = "Bebek, Beşiktaş, Türkiye",
                            City = "İstanbul",
                            Country = "Türkiye",
                            CreatedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(2973),
                            Description = "Diş sağlığı hizmetleri sunan dişçi kliniği.",
                            ImageUrl = "disci.jpg",
                            IsActive = false,
                            IsDeleted = false,
                            IsHome = false,
                            MailAdress = "info@disci.com",
                            ModifiedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(2973),
                            Name = "İtina Dişçi",
                            PhoneNumber = "1234567890",
                            Town = "Beşiktaş",
                            Url = "www.disci.com"
                        },
                        new
                        {
                            Id = 6,
                            Address = "Moda Caddesi, Kadıköy, Türkiye",
                            City = "İstanbul",
                            Country = "Türkiye",
                            CreatedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(2976),
                            Description = "Profesyonel hizmetlerle kiralık katil işleri yapan gizli dükkân.",
                            ImageUrl = "kiralik-katil.jpg",
                            IsActive = true,
                            IsDeleted = false,
                            IsHome = true,
                            MailAdress = "info@kiralik-katil.com",
                            ModifiedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(2976),
                            Name = "Prof Kiralık Katil",
                            PhoneNumber = "1234567890",
                            Town = "Kadıköy",
                            Url = "www.kiralik-katil.com"
                        },
                        new
                        {
                            Id = 7,
                            Address = "Sultanahmet Meydanı, Fatih, Türkiye",
                            City = "İstanbul",
                            Country = "Türkiye",
                            CreatedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(2980),
                            Description = "Fitness ve spor salonu.",
                            ImageUrl = "gym.jpg",
                            IsActive = false,
                            IsDeleted = false,
                            IsHome = false,
                            MailAdress = "info@gym.com",
                            ModifiedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(2980),
                            Name = "Şişman Gym",
                            PhoneNumber = "1234567890",
                            Town = "Fatih",
                            Url = "www.gym.com"
                        },
                        new
                        {
                            Id = 8,
                            Address = "Ortaköy, Beşiktaş, Türkiye",
                            City = "İstanbul",
                            Country = "Türkiye",
                            CreatedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(3019),
                            Description = "Lezzetli mantı çeşitlerinin servis edildiği mantı dükkânı.",
                            ImageUrl = "mantici.jpg",
                            IsActive = true,
                            IsDeleted = false,
                            IsHome = true,
                            MailAdress = "info@mantici.com",
                            ModifiedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(3020),
                            Name = "Enfes Mantıcı",
                            PhoneNumber = "1234567890",
                            Town = "Beşiktaş",
                            Url = "www.mantici.com"
                        },
                        new
                        {
                            Id = 9,
                            Address = "Kadıköy İskelesi, Kadıköy, Türkiye",
                            City = "İstanbul",
                            Country = "Türkiye",
                            CreatedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(3024),
                            Description = "Futbol oynamak için ideal bir saha.",
                            ImageUrl = "futbol-sahasi.jpg",
                            IsActive = false,
                            IsDeleted = false,
                            IsHome = false,
                            MailAdress = "info@futbol-sahasi.com",
                            ModifiedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(3024),
                            Name = "Yeşil Futbol Sahası",
                            PhoneNumber = "1234567890",
                            Town = "Kadıköy",
                            Url = "www.futbol-sahasi.com"
                        },
                        new
                        {
                            Id = 10,
                            Address = "Taksim Meydanı, Beyoğlu, Türkiye",
                            City = "İstanbul",
                            Country = "Türkiye",
                            CreatedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(3027),
                            Description = "Ayakkabı tamir ve bakımı yapan lostra dükkânı.",
                            ImageUrl = "lostra.jpg",
                            IsActive = true,
                            IsDeleted = false,
                            IsHome = true,
                            MailAdress = "info@lostra.com",
                            ModifiedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(3027),
                            Name = "Dikkat Lostra",
                            PhoneNumber = "1234567890",
                            Town = "Beyoğlu",
                            Url = "www.lostra.com"
                        },
                        new
                        {
                            Id = 11,
                            Address = "İstiklal Caddesi, Beyoğlu, Türkiye",
                            City = "İstanbul",
                            Country = "Türkiye",
                            CreatedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(3030),
                            Description = "Sevilen mahalle bakkal amcanız.",
                            ImageUrl = "bakkal.jpg",
                            IsActive = false,
                            IsDeleted = false,
                            IsHome = false,
                            MailAdress = "info@rafik-kasap.com",
                            ModifiedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(3030),
                            Name = "Rafık Bakkal",
                            PhoneNumber = "1234567890",
                            Town = "Beyoğlu",
                            Url = "www.rafik-bakkal.com"
                        },
                        new
                        {
                            Id = 12,
                            Address = "Merkez Mahallesi, İstanbul, Türkiye",
                            City = "İstanbul",
                            Country = "Türkiye",
                            CreatedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(3033),
                            Description = "Lezzetli yemekler sunan restoran.",
                            ImageUrl = "restoran.jpg",
                            IsActive = true,
                            IsDeleted = false,
                            IsHome = false,
                            MailAdress = "info@lezzet-restoran.com",
                            ModifiedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(3033),
                            Name = "Lezzet Restoran",
                            PhoneNumber = "1234567890",
                            Town = "Şişli",
                            Url = "www.lezzet-restoran.com"
                        },
                        new
                        {
                            Id = 13,
                            Address = "Bahçe Sokak, Ankara, Türkiye",
                            City = "Ankara",
                            Country = "Türkiye",
                            CreatedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(3035),
                            Description = "Keyifli bir ortamda kahve ve atıştırmalıklar sunan kafe.",
                            ImageUrl = "kafe.jpg",
                            IsActive = true,
                            IsDeleted = false,
                            IsHome = true,
                            MailAdress = "info@keyifli-kafe.com",
                            ModifiedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(3036),
                            Name = "Keyifli Kafe",
                            PhoneNumber = "1234567890",
                            Town = "Çankaya",
                            Url = "www.keyifli-kafe.com"
                        },
                        new
                        {
                            Id = 14,
                            Address = "Bağdat Caddesi, Kadıköy, Türkiye",
                            City = "İstanbul",
                            Country = "Türkiye",
                            CreatedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(3038),
                            Description = "Moda ve stilin buluştuğu şık butik mağaza.",
                            ImageUrl = "butik.jpg",
                            IsActive = true,
                            IsDeleted = false,
                            IsHome = false,
                            MailAdress = "info@sik-butik.com",
                            ModifiedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(3039),
                            Name = "Şık Butik",
                            PhoneNumber = "1234567890",
                            Town = "Kadıköy",
                            Url = "www.sik-butik.com"
                        },
                        new
                        {
                            Id = 15,
                            Address = "İzmir Caddesi, İzmir, Türkiye",
                            City = "İzmir",
                            Country = "Türkiye",
                            CreatedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(3041),
                            Description = "Gözlük ve güneş gözlüğü mağazası.",
                            ImageUrl = "optik.jpg",
                            IsActive = false,
                            IsDeleted = false,
                            IsHome = false,
                            MailAdress = "info@net-optik.com",
                            ModifiedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(3042),
                            Name = "Net Optik",
                            PhoneNumber = "1234567890",
                            Town = "Konak",
                            Url = "www.net-optik.com"
                        },
                        new
                        {
                            Id = 16,
                            Address = "Bağlar Sokak, Bursa, Türkiye",
                            City = "Bursa",
                            Country = "Türkiye",
                            CreatedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(3044),
                            Description = "Konforlu ve şık mobilyaların satıldığı mağaza.",
                            ImageUrl = "mobilya.jpg",
                            IsActive = true,
                            IsDeleted = false,
                            IsHome = true,
                            MailAdress = "info@rahat-mobilya.com",
                            ModifiedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(3045),
                            Name = "Rahat Mobilya Mağazası",
                            PhoneNumber = "1234567890",
                            Town = "Osmangazi",
                            Url = "www.rahat-mobilya.com"
                        },
                        new
                        {
                            Id = 17,
                            Address = "Çocuklar Caddesi, Antalya, Türkiye",
                            City = "Antalya",
                            Country = "Türkiye",
                            CreatedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(3048),
                            Description = "Eğlenceli ve renkli oyuncakların satıldığı oyuncakçı dükkanı.",
                            ImageUrl = "oyuncakci.jpg",
                            IsActive = true,
                            IsDeleted = false,
                            IsHome = false,
                            MailAdress = "info@neseli-oyuncakci.com",
                            ModifiedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(3048),
                            Name = "Neşeli Oyuncakçı",
                            PhoneNumber = "1234567890",
                            Town = "Muratpaşa",
                            Url = "www.neseli-oyuncakci.com"
                        },
                        new
                        {
                            Id = 18,
                            Address = "Teknoloji Sokak, İzmit, Türkiye",
                            City = "Kocaeli",
                            Country = "Türkiye",
                            CreatedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(3051),
                            Description = "Son teknoloji elektronik ürünlerin satıldığı mağaza.",
                            ImageUrl = "elektronik.jpg",
                            IsActive = false,
                            IsDeleted = false,
                            IsHome = false,
                            MailAdress = "info@teknoloji-elektronik.com",
                            ModifiedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(3051),
                            Name = "Teknoloji Elektronik Mağaza",
                            PhoneNumber = "1234567890",
                            Town = "İzmit",
                            Url = "www.teknoloji-elektronik.com"
                        },
                        new
                        {
                            Id = 19,
                            Address = "Çiçekler Sokak, Adana, Türkiye",
                            City = "Adana",
                            Country = "Türkiye",
                            CreatedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(3054),
                            Description = "Canlı ve renkli çiçeklerin satıldığı çiçekçi dükkanı.",
                            ImageUrl = "cicekci.jpg",
                            IsActive = true,
                            IsDeleted = false,
                            IsHome = true,
                            MailAdress = "info@renkli-cicekci.com",
                            ModifiedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(3054),
                            Name = "Renkli Çiçekçi",
                            PhoneNumber = "1234567890",
                            Town = "Seyhan",
                            Url = "www.renkli-cicekci.com"
                        },
                        new
                        {
                            Id = 20,
                            Address = "Kitaplar Sokak, İstanbul, Türkiye",
                            City = "İstanbul",
                            Country = "Türkiye",
                            CreatedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(3057),
                            Description = "Geniş bir kitap koleksiyonuna sahip olan kitapçı.",
                            ImageUrl = "kitapci.jpg",
                            IsActive = true,
                            IsDeleted = false,
                            IsHome = false,
                            MailAdress = "info@bilge-kitapci.com",
                            ModifiedDate = new DateTime(2023, 7, 8, 1, 14, 20, 87, DateTimeKind.Local).AddTicks(3057),
                            Name = "Bilge Kitapçı",
                            PhoneNumber = "1234567890",
                            Town = "Kadıköy",
                            Url = "www.bilge-kitapci.com"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
