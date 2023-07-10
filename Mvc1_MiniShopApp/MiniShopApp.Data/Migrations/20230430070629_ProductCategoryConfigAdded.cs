using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniShopApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductCategoryConfigAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 30, 10, 6, 29, 187, DateTimeKind.Local).AddTicks(4865), new DateTime(2023, 4, 30, 10, 6, 29, 187, DateTimeKind.Local).AddTicks(4882) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 30, 10, 6, 29, 187, DateTimeKind.Local).AddTicks(4886), new DateTime(2023, 4, 30, 10, 6, 29, 187, DateTimeKind.Local).AddTicks(4887) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 30, 10, 6, 29, 187, DateTimeKind.Local).AddTicks(4889), new DateTime(2023, 4, 30, 10, 6, 29, 187, DateTimeKind.Local).AddTicks(4890) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 30, 10, 6, 29, 187, DateTimeKind.Local).AddTicks(4893), new DateTime(2023, 4, 30, 10, 6, 29, 187, DateTimeKind.Local).AddTicks(4894) });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 1 },
                    { 1, 2 },
                    { 3, 2 },
                    { 1, 3 },
                    { 3, 3 },
                    { 1, 4 },
                    { 3, 4 },
                    { 3, 5 },
                    { 4, 5 },
                    { 3, 6 },
                    { 4, 6 },
                    { 3, 7 },
                    { 4, 7 },
                    { 2, 8 },
                    { 4, 8 },
                    { 2, 9 },
                    { 4, 9 },
                    { 2, 10 },
                    { 4, 10 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 30, 10, 6, 29, 188, DateTimeKind.Local).AddTicks(355), new DateTime(2023, 4, 30, 10, 6, 29, 188, DateTimeKind.Local).AddTicks(368) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 30, 10, 6, 29, 188, DateTimeKind.Local).AddTicks(375), new DateTime(2023, 4, 30, 10, 6, 29, 188, DateTimeKind.Local).AddTicks(376) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 30, 10, 6, 29, 188, DateTimeKind.Local).AddTicks(380), new DateTime(2023, 4, 30, 10, 6, 29, 188, DateTimeKind.Local).AddTicks(381) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 30, 10, 6, 29, 188, DateTimeKind.Local).AddTicks(386), new DateTime(2023, 4, 30, 10, 6, 29, 188, DateTimeKind.Local).AddTicks(387) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 30, 10, 6, 29, 188, DateTimeKind.Local).AddTicks(390), new DateTime(2023, 4, 30, 10, 6, 29, 188, DateTimeKind.Local).AddTicks(391) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 30, 10, 6, 29, 188, DateTimeKind.Local).AddTicks(394), new DateTime(2023, 4, 30, 10, 6, 29, 188, DateTimeKind.Local).AddTicks(395) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 30, 10, 6, 29, 188, DateTimeKind.Local).AddTicks(399), new DateTime(2023, 4, 30, 10, 6, 29, 188, DateTimeKind.Local).AddTicks(399) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 30, 10, 6, 29, 188, DateTimeKind.Local).AddTicks(402), new DateTime(2023, 4, 30, 10, 6, 29, 188, DateTimeKind.Local).AddTicks(403) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 30, 10, 6, 29, 188, DateTimeKind.Local).AddTicks(406), new DateTime(2023, 4, 30, 10, 6, 29, 188, DateTimeKind.Local).AddTicks(407) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 30, 10, 6, 29, 188, DateTimeKind.Local).AddTicks(410), new DateTime(2023, 4, 30, 10, 6, 29, 188, DateTimeKind.Local).AddTicks(411) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 4, 10 });

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

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4858), new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4863) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4868), new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4869) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4871), new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4872) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4874), new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4875) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4877), new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4878) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4880), new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4881) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4883), new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4883) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4885), new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4886) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4888), new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4889) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4891), new DateTime(2023, 4, 30, 9, 45, 34, 671, DateTimeKind.Local).AddTicks(4891) });
        }
    }
}
