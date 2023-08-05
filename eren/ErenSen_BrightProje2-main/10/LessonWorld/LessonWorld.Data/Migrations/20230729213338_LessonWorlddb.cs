using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LessonWorld.Data.Migrations
{
    /// <inheritdoc />
    public partial class LessonWorlddb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    BirthOfYear = table.Column<int>(type: "INTEGER", nullable: false),
                    IsAlive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    About = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    PhotoUrl = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    OrderStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    LessonTime = table.Column<int>(type: "INTEGER", nullable: false),
                    IsHome = table.Column<bool>(type: "INTEGER", nullable: false),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: true),
                    SchoolId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Lessons_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LessonId = table.Column<int>(type: "INTEGER", nullable: false),
                    CartId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonCategories",
                columns: table => new
                {
                    LessonId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonCategories", x => new { x.LessonId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_LessonCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonCategories_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    LessonId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27044e04-b191-4154-8f62-29ccd733b583", null, "Diğer tüm kullanıcıların rolü bu.", "Normal", "NORMAL" },
                    { "2e1658d9-8fff-4ce5-9c9e-8ad51308a829", null, "Diğer tüm kullanıcıların rolü bu.", "User", "USER" },
                    { "4db54d14-ced0-4fcd-98a8-98f0c765efb3", null, "Diğer tüm kullanıcıların rolü bu.", "Strict", "STRICT" },
                    { "6b5a9ac5-787a-4e67-961d-7f5a2e1f79fa", null, "Diğer tüm kullanıcıların rolü bu.", "Editor", "EDITOR" },
                    { "d13cd4a7-18ca-4084-9cda-a32d735a927b", null, "Yöneticilerin rolü bu.", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "d64545e2-8acd-4b2f-adf2-20da519eca19", 0, "Hürriyet Mh. Doktor Cemil Bnegü Caddesi No:88 D:10 Kağıthane", "İstanbul", "e6cb2b15-b11e-48b4-b56c-06aa4bc59709", new DateTime(1983, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "elanursen@gmail.com", true, "Elanur", "Kadın", "Şen", true, null, " ", "ELANURSEN@GMAIL.COM", "USER", "AQAAAAIAAYagAAAAECLbgEq/6TLWN/kQoHor1D+n2KKUEfQO6MiSGTxJeIenoxnhmQmjwgXiwVlnAM/BJA==", "+905379249326", true, "", false, "user" },
                    { "f4bed8c0-18e8-4ca6-802b-28e699fc01fc", 0, "Hürriyet Mh. Doktor Cemil Bnegü Caddesi No:88 D:10 Kağıthane", "İstanbul", "e9a2714e-04d0-4031-8a44-4e56b32d9b6d", new DateTime(1994, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "erenlersen1@gmail.com", true, "Eren", "Erkek", "Şen", true, null, " ", "ERENLERSEN1@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEOIqFThhAmxBtUqwsscxY43su43jYfGvaG3cfcoGuMTrdJNFmFtIZF84QZ9mt8p95w==", "+905335219128", true, "", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedDate", "Name", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 30, 0, 33, 38, 473, DateTimeKind.Local).AddTicks(7463), "Spor Dersleri Basketbol,Futbol,Volaybol,Yüzme,Koşu", true, false, new DateTime(2023, 7, 30, 0, 33, 38, 473, DateTimeKind.Local).AddTicks(7469), "Spor", "spor-dersleri" },
                    { 2, new DateTime(2023, 7, 30, 0, 33, 38, 473, DateTimeKind.Local).AddTicks(7473), "Sanat Derleri,Heykel Traş,Resim,Mozaik,Seramik,Temel Tasarım", true, false, new DateTime(2023, 7, 30, 0, 33, 38, 473, DateTimeKind.Local).AddTicks(7473), "Sanat", "sanat-dersleri" },
                    { 3, new DateTime(2023, 7, 30, 0, 33, 38, 473, DateTimeKind.Local).AddTicks(7475), "Sözel Dersler Türkçe,Tarih,Felsefe,Edebiyat,Dil Anlatım", true, false, new DateTime(2023, 7, 30, 0, 33, 38, 473, DateTimeKind.Local).AddTicks(7476), "Sözel", "sozel-dersleri" },
                    { 4, new DateTime(2023, 7, 30, 0, 33, 38, 473, DateTimeKind.Local).AddTicks(7477), "Sayısal Dersler Matematik,Fizik,Kimya Biyoloji,Geometri", true, false, new DateTime(2023, 7, 30, 0, 33, 38, 473, DateTimeKind.Local).AddTicks(7477), "Sayısal", "sayisal-dersleri" },
                    { 5, new DateTime(2023, 7, 30, 0, 33, 38, 473, DateTimeKind.Local).AddTicks(7478), "Enstürman Dersleri Gitar,Keman,Saz,Piyano,Saksafon", true, false, new DateTime(2023, 7, 30, 0, 33, 38, 473, DateTimeKind.Local).AddTicks(7479), "Enstürman", "enstürman-dersleri" }
                });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "City", "Country", "CreatedDate", "IsActive", "IsDeleted", "ModifiedDate", "Name", "Phone", "Url" },
                values: new object[,]
                {
                    { 1, "İstanbul", "Türkiye", new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(9087), true, false, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(9093), "Beşiktaş Koleji", "02122321933", "besiktas-koleji" },
                    { 2, "İstanbul", "Türkiye", new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(9097), true, false, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(9097), "Kartal Akademi", "02164785696", "kartal-akademi" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "About", "BirthOfYear", "CreatedDate", "FirstName", "IsActive", "IsAlive", "IsDeleted", "LastName", "ModifiedDate", "PhotoUrl", "Url" },
                values: new object[,]
                {
                    { 1, "Spor Alanı Öğretmeni", 1980, new DateTime(2023, 7, 30, 0, 33, 38, 476, DateTimeKind.Local).AddTicks(3962), "Hamza", true, false, false, "Hakan", new DateTime(2023, 7, 30, 0, 33, 38, 476, DateTimeKind.Local).AddTicks(3970), "hamza-hakan.jpg", "hamza-hakan-1" },
                    { 2, "Spor Alanı Öğretmeni", 1985, new DateTime(2023, 7, 30, 0, 33, 38, 476, DateTimeKind.Local).AddTicks(3976), "Deniz", true, true, false, "Keskin", new DateTime(2023, 7, 30, 0, 33, 38, 476, DateTimeKind.Local).AddTicks(3977), "deniz-keskin.jpg", "deniz-keskin-2" },
                    { 3, "Sanat Alanı Öğretmeni", 1982, new DateTime(2023, 7, 30, 0, 33, 38, 476, DateTimeKind.Local).AddTicks(3979), "Sedef", true, false, false, "Arak", new DateTime(2023, 7, 30, 0, 33, 38, 476, DateTimeKind.Local).AddTicks(3980), "sedef-arak.jpg", "sedef-arak-3" },
                    { 4, "Sanat Alanı Öğretmeni", 1990, new DateTime(2023, 7, 30, 0, 33, 38, 476, DateTimeKind.Local).AddTicks(3982), "Hakan", true, false, false, "Tan", new DateTime(2023, 7, 30, 0, 33, 38, 476, DateTimeKind.Local).AddTicks(3983), "hakan-tan.jpg", "hakan-tan-4" },
                    { 5, "Sözel Alan Öğretmeni", 1982, new DateTime(2023, 7, 30, 0, 33, 38, 476, DateTimeKind.Local).AddTicks(3985), "Aysun", true, true, false, "Yılmaz", new DateTime(2023, 7, 30, 0, 33, 38, 476, DateTimeKind.Local).AddTicks(3985), "aysun-yilmaz.jpg", "aysun-yilmaz-5" },
                    { 6, "Sözel Alan Öğretmeni", 1987, new DateTime(2023, 7, 30, 0, 33, 38, 476, DateTimeKind.Local).AddTicks(3989), "Mine", true, false, false, "Kar", new DateTime(2023, 7, 30, 0, 33, 38, 476, DateTimeKind.Local).AddTicks(3989), "mine-kar.jpg", "mine-kar-6" },
                    { 7, "Sayısal Alan Öğretmeni ", 1975, new DateTime(2023, 7, 30, 0, 33, 38, 476, DateTimeKind.Local).AddTicks(3991), "Mehmet", true, false, false, "Dar", new DateTime(2023, 7, 30, 0, 33, 38, 476, DateTimeKind.Local).AddTicks(3992), "mehmet-dar.jpg", "mehmet-dar-7" },
                    { 8, "Sayısal Alan Öğretmeni ", 1980, new DateTime(2023, 7, 30, 0, 33, 38, 476, DateTimeKind.Local).AddTicks(3993), "Osman", true, false, false, "Hak", new DateTime(2023, 7, 30, 0, 33, 38, 476, DateTimeKind.Local).AddTicks(3994), "osman-hak.jpg", "osman-hak-8" },
                    { 9, "Enstürman Alanı Öğretmeni", 1982, new DateTime(2023, 7, 30, 0, 33, 38, 476, DateTimeKind.Local).AddTicks(3996), "Kayahan", true, true, false, "Keten", new DateTime(2023, 7, 30, 0, 33, 38, 476, DateTimeKind.Local).AddTicks(3996), "kayahan-keten.jpg", "kayahan-keten-9" },
                    { 10, " Enstürman Alanı Öğretmeni ", 1992, new DateTime(2023, 7, 30, 0, 33, 38, 476, DateTimeKind.Local).AddTicks(3998), "Ela", true, false, false, "Kara", new DateTime(2023, 7, 30, 0, 33, 38, 476, DateTimeKind.Local).AddTicks(3999), "ela-kara.jpg", "ela-kara-10" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2e1658d9-8fff-4ce5-9c9e-8ad51308a829", "d64545e2-8acd-4b2f-adf2-20da519eca19" },
                    { "d13cd4a7-18ca-4084-9cda-a32d735a927b", "f4bed8c0-18e8-4ca6-802b-28e699fc01fc" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "CreatedDate", "IsActive", "IsDeleted", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 30, 0, 33, 38, 473, DateTimeKind.Local).AddTicks(170), true, false, new DateTime(2023, 7, 30, 0, 33, 38, 473, DateTimeKind.Local).AddTicks(204), "f4bed8c0-18e8-4ca6-802b-28e699fc01fc" },
                    { 2, new DateTime(2023, 7, 30, 0, 33, 38, 473, DateTimeKind.Local).AddTicks(210), true, false, new DateTime(2023, 7, 30, 0, 33, 38, 473, DateTimeKind.Local).AddTicks(210), "d64545e2-8acd-4b2f-adf2-20da519eca19" }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "IsActive", "IsDeleted", "IsHome", "LessonTime", "ModifiedDate", "Name", "Price", "SchoolId", "TeacherId", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(3966), "Basketbol  alanında gelişim eğitimi", "basketbol.jpg", true, false, false, 0, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(3975), "Basketbol", 100m, 1, 1, "basketbol-1" },
                    { 2, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(3983), "Futbol  alanında gelişim eğitimi", "futbol.jpg", true, false, false, 0, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(3984), "Futbol", 100m, 1, 2, "Futbol-2" },
                    { 3, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(3987), "Voleybol  alanında gelişim eğitimi", "voleybol.jpg", true, false, false, 0, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(3987), "Voleybol", 100m, 1, 1, "voleybol-3" },
                    { 4, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(3989), "Yüzme  alanında gelişim eğitimi", "yuzme.jpg", true, false, false, 0, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(3990), "Yüzme", 100m, 1, 2, "yuzme-4" },
                    { 5, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(3991), "Koşu alanında gelişim eğitimi", "kosu.jpg", true, false, false, 0, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(3992), "Koşu", 100m, 1, 1, "kosu-5" },
                    { 6, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(3994), "Heykel Traş  alanında gelişim eğitimi", "tras.jpg", true, false, false, 0, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(3994), "Heykel Traş", 100m, 1, 3, "tras-6" },
                    { 7, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(3996), "Resim  alanında gelişim eğitimi", "resim.jpg", true, false, false, 0, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(3996), "Resim", 100m, 1, 3, "resim-7" },
                    { 8, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(3998), "Temel Tasarım  alanında gelişim eğitimi", "tras.jpg", true, false, false, 0, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4005), "Temel Tasarım", 100m, 1, 3, "temel-tasarım-8" },
                    { 9, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4016), "Mozaik  alanında gelişim eğitimi", "mozaik.jpg", true, false, false, 0, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4016), "Mozaik", 100m, 1, 4, "mozaik-9" },
                    { 10, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4019), "Seramik  alanında gelişim eğitimi", "seramik.jpg", true, false, false, 0, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4019), "Seramik", 100m, 1, 4, "seramik-10" },
                    { 11, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4021), "Türkçe  alanında gelişim eğitimi", "turkce.jpg", true, false, false, 0, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4022), "Türkçe", 100m, 1, 5, "turkce-11" },
                    { 12, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4024), "Edebiyat  alanında gelişim eğitimi", "edebiyat.jpg", true, false, false, 0, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4024), "Edebiyat", 100m, 1, 5, "edebiyat-12" },
                    { 13, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4027), "Dil Anlatım  alanında gelişim eğitimi", "dil-anlatim.jpg", true, false, false, 0, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4027), "Dil Anlatım", 100m, 1, 5, "dil-analatim-13" },
                    { 14, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4029), "Tarih alanında gelişim eğitimi", "tarih.jpg", true, false, false, 0, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4030), "Tarih", 100m, 1, 6, "tarih-14" },
                    { 15, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4031), "Felsefe  alanında gelişim eğitimi", "felsefe.jpg", true, false, false, 0, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4032), "Felsefe", 100m, 1, 6, "felsefe-15" },
                    { 16, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4034), "Matematik  alanında gelişim eğitimi", "matematik.jpg", true, false, false, 0, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4034), "Matematik", 100m, 1, 7, "matematik-16" },
                    { 17, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4036), "Geometri  alanında gelişim eğitimi", "geometri.jpg", true, false, false, 0, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4036), "Geometri", 100m, 1, 7, "geometri-17" },
                    { 18, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4044), "Fizik  alanında gelişim eğitimi", "fizik.jpg", true, false, false, 0, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4044), "Fizik", 100m, 1, 7, "fizik-18" },
                    { 19, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4046), "Kimya  alanında gelişim eğitimi", "kimya.jpg", true, false, false, 0, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4047), "Kimya", 100m, 1, 8, "kimya-19" },
                    { 20, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4049), "Biyoloji  alanında gelişim eğitimi", "Biyoloji.jpg", true, false, false, 0, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4049), "Biyoloji", 100m, 1, 8, "biyoloji-20" },
                    { 21, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4052), "Geometri  alanında gelişim eğitimi", "gitar.jpg", true, false, false, 0, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4052), "Gitar", 100m, 1, 9, "gitar-21" },
                    { 22, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4056), "Saz  alanında gelişim eğitimi", "saz.jpg", true, false, false, 0, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4056), "Saz", 100m, 1, 9, "saz-22" },
                    { 23, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4059), "Keman  alanında gelişim eğitimi", "keman.jpg", true, false, false, 0, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4060), "Keman", 100m, 1, 9, "keman-23" },
                    { 24, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4062), "Piyano  alanında gelişim eğitimi", "piyano.jpg", true, false, false, 0, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4063), "Piyano", 100m, 1, 10, "piyano-24" },
                    { 25, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4066), "Saksafon  alanında gelişim eğitimi", "saksafon.jpg", true, false, false, 0, new DateTime(2023, 7, 30, 0, 33, 38, 475, DateTimeKind.Local).AddTicks(4066), "Saksafon", 100m, 1, 10, "saksafon-25" }
                });

            migrationBuilder.InsertData(
                table: "LessonCategories",
                columns: new[] { "CategoryId", "LessonId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 2, 9 },
                    { 2, 10 },
                    { 3, 11 },
                    { 3, 12 },
                    { 3, 13 },
                    { 3, 14 },
                    { 3, 15 },
                    { 4, 16 },
                    { 4, 17 },
                    { 4, 18 },
                    { 4, 19 },
                    { 4, 20 },
                    { 5, 21 },
                    { 5, 22 },
                    { 5, 23 },
                    { 5, 24 },
                    { 5, 25 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_LessonId",
                table: "CartItems",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonCategories_CategoryId",
                table: "LessonCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_SchoolId",
                table: "Lessons",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TeacherId",
                table: "Lessons",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_LessonId",
                table: "OrderItems",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "LessonCategories");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
