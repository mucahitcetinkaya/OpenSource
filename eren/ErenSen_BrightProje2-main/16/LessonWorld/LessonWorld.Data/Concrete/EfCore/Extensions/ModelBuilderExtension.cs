using LessonWorld.Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonWorld.Data.Concrete.EfCore.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            #region Rol Bilgileri
            List<Role> roles = new List<Role>
            {
                new Role { Name="Admin", Description="Yöneticilerin rolü bu.", NormalizedName="ADMIN"},
                new Role { Name="User", Description="Diğer tüm kullanıcıların rolü bu.", NormalizedName="USER"},
                new Role { Name="Superviser", Description="Superviser kullanıcıların rolü bu.", NormalizedName="SUPERVİSER"},
                new Role { Name="Student", Description="Student kullanıcıların rolü bu.", NormalizedName="STUDENT"}
            };
            modelBuilder.Entity<Role>().HasData(roles);
            #endregion
            #region Kullanıcı Bilgileri
            List<User> users = new List<User>
            {
                new User
                {
                    FirstName="Eren",
                    LastName="Şen",
                    UserName="admin",
                    NormalizedUserName="ADMIN",
                    Email="erenlersen1@gmail.com",
                    NormalizedEmail="ERENLERSEN1@GMAIL.COM",
                    Gender="Erkek",
                    DateOfBirth= new DateTime(1994,9,04),
                    Address="Hürriyet Mh. Doktor Cemil Bnegü Caddesi No:88 D:10 Kağıthane",
                    City="İstanbul",
                    EmailConfirmed=true,
                    SecurityStamp="",
                    LockoutEnabled=true,
                    PhoneNumber="+905335219128",
                    PhoneNumberConfirmed=true
                },
                new User
                {
                    FirstName="Elanur",
                    LastName="Şen",
                    UserName="user",
                    NormalizedUserName="USER",
                    Email="elanursen@gmail.com",
                    NormalizedEmail="ELANURSEN@GMAIL.COM",
                    Gender="Kadın",
                    DateOfBirth= new DateTime(1983,9,10),
                    Address="Hürriyet Mh. Doktor Cemil Bnegü Caddesi No:88 D:10 Kağıthane",
                    City="İstanbul",
                    EmailConfirmed=true,
                    SecurityStamp="",
                    LockoutEnabled=true,
                    PhoneNumber="+905379249326",
                    PhoneNumberConfirmed=true
                }
            };
            modelBuilder.Entity<User>().HasData(users);
            #endregion
            #region Şifre İşlemleri
            var passwordHasher = new PasswordHasher<User>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Eren123.");
            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Eren123.");
            #endregion
            #region Rol Atama İşlemleri
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>{ UserId=users[0].Id, RoleId=roles[0].Id },
                new IdentityUserRole<string>{ UserId=users[1].Id, RoleId=roles[1].Id }
            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            #endregion
            #region Alışveriş Sepeti İşlemleri
            List<Cart> carts = new List<Cart>
            {
                new Cart{ Id=1, UserId=users[0].Id},
                new Cart{ Id=2, UserId=users[1].Id}
            };
            modelBuilder.Entity<Cart>().HasData(carts);
            #endregion
        }
    }
}
