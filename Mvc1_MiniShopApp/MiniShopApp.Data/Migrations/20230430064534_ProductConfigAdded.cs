using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniShopApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductConfigAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Properties",
                table: "Products",
                type: "TEXT",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(2571), new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(2582) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(2586), new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(2586) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(2588), new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(2589) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(2591), new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(2591) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "ImageUrl", "IsActive", "IsDeleted", "IsHome", "ModifiedDate", "Name", "Price", "Properties", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4858), "1.png", true, false, true, new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4863), "IPhone 13", 29000m, "Harika bir telefon", "iphone-13" },
                    { 2, new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4868), "2.png", true, false, false, new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4869), "Samsung S23 Plus", 39000m, "Harika bir telefon diyorlar", "samsung-s23-plus" },
                    { 3, new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4871), "3.png", true, false, true, new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4872), "Iphone 14 Pro Plus", 49000m, "Harika bir telefon ama...", "iphone-14-pro-plus" },
                    { 4, new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4874), "4.png", true, false, false, new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4875), "Huawei Mate 20D", 21000m, "Fiyat/Performans ürünü", "huawei-mate-20d" },
                    { 5, new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4877), "5.png", true, false, true, new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4878), "Vestel NFR 7500", 23000m, "Nofrost", "vestel-nfr-7500" },
                    { 6, new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4880), "6.png", true, false, false, new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4881), "Arçelik AR8000 Toz Torbasız", 7000m, "Toz torbasına son", "arcelik-ar8000-toz-torbasiz" },
                    { 7, new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4883), "7.png", true, false, false, new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4883), "Arzum Okka Türk Kahvesi Makinesi", 1300m, "Türk kahvesini dünyaya tanıtan marka", "arzum-okka-turk-kahvesi-makinesi" },
                    { 8, new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4885), "8.png", true, false, true, new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4886), "Macbook Air M2 16 Gb", 24500m, "Daha güçlü", "macbook-air-m2-16-gb" },
                    { 9, new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4888), "9.png", true, false, false, new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4889), "Asus Zenbook 12X", 22000m, "Fan mı? O da ne?", "asus-zenbook-12x" },
                    { 10, new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4891), "10.png", true, false, false, new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4891), "Dell TRE Amd Ryzen", 26500m, "32 Gb Ram", "dell-tre-amd-ryzen" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Products",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Properties",
                table: "Products",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 29, 14, 51, 25, 567, DateTimeKind.Local).AddTicks(7516), new DateTime(2023, 4, 29, 14, 51, 25, 567, DateTimeKind.Local).AddTicks(7528) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 29, 14, 51, 25, 567, DateTimeKind.Local).AddTicks(7531), new DateTime(2023, 4, 29, 14, 51, 25, 567, DateTimeKind.Local).AddTicks(7531) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 29, 14, 51, 25, 567, DateTimeKind.Local).AddTicks(7533), new DateTime(2023, 4, 29, 14, 51, 25, 567, DateTimeKind.Local).AddTicks(7534) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 29, 14, 51, 25, 567, DateTimeKind.Local).AddTicks(7536), new DateTime(2023, 4, 29, 14, 51, 25, 567, DateTimeKind.Local).AddTicks(7536) });
        }
    }
}
