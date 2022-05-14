using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFStore.Migrations
{
    public partial class InitCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("76ddb584-af5e-4b9e-9498-01295496fdd2"), new Guid("1f14e8e7-3900-43a4-980b-6d46e9a301a5") });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("3408896e-2c5c-4285-899b-3d760002ccfa"), new Guid("98971972-7b24-4c7c-807f-78414bf5e52f") });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("043074b5-16ec-4112-b2e9-331ad5ad1f83"), new Guid("a4ca47bb-1b48-4eed-ad30-4a41352d4834") });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("043074b5-16ec-4112-b2e9-331ad5ad1f83"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3408896e-2c5c-4285-899b-3d760002ccfa"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("76ddb584-af5e-4b9e-9498-01295496fdd2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1f14e8e7-3900-43a4-980b-6d46e9a301a5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("98971972-7b24-4c7c-807f-78414bf5e52f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a4ca47bb-1b48-4eed-ad30-4a41352d4834"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2002c723-cee3-4b47-9fa7-ea0a631a41f4"), "Cat1" },
                    { new Guid("a6863264-e507-439b-b383-56848125bc13"), "Cat2" },
                    { new Guid("f5a17e95-ca1d-43e1-841b-bf02929453f3"), "Cat3" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Manufacture", "Name" },
                values: new object[,]
                {
                    { new Guid("d341767c-aee0-4f33-8af4-c6b9ba3fbca5"), "M1", "Pro1" },
                    { new Guid("c74e68e5-c38c-4686-8adc-cc821c85bba4"), "M2", "Pro2" },
                    { new Guid("9c8236d7-9d72-4d62-8866-8aa037b744e2"), "M3", "Pro3" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { new Guid("f5a17e95-ca1d-43e1-841b-bf02929453f3"), new Guid("d341767c-aee0-4f33-8af4-c6b9ba3fbca5") });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { new Guid("2002c723-cee3-4b47-9fa7-ea0a631a41f4"), new Guid("c74e68e5-c38c-4686-8adc-cc821c85bba4") });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { new Guid("a6863264-e507-439b-b383-56848125bc13"), new Guid("9c8236d7-9d72-4d62-8866-8aa037b744e2") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("a6863264-e507-439b-b383-56848125bc13"), new Guid("9c8236d7-9d72-4d62-8866-8aa037b744e2") });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("2002c723-cee3-4b47-9fa7-ea0a631a41f4"), new Guid("c74e68e5-c38c-4686-8adc-cc821c85bba4") });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("f5a17e95-ca1d-43e1-841b-bf02929453f3"), new Guid("d341767c-aee0-4f33-8af4-c6b9ba3fbca5") });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2002c723-cee3-4b47-9fa7-ea0a631a41f4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a6863264-e507-439b-b383-56848125bc13"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f5a17e95-ca1d-43e1-841b-bf02929453f3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c8236d7-9d72-4d62-8866-8aa037b744e2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c74e68e5-c38c-4686-8adc-cc821c85bba4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d341767c-aee0-4f33-8af4-c6b9ba3fbca5"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("043074b5-16ec-4112-b2e9-331ad5ad1f83"), "Cat1" },
                    { new Guid("3408896e-2c5c-4285-899b-3d760002ccfa"), "Cat2" },
                    { new Guid("76ddb584-af5e-4b9e-9498-01295496fdd2"), "Cat3" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Manufacture", "Name" },
                values: new object[,]
                {
                    { new Guid("1f14e8e7-3900-43a4-980b-6d46e9a301a5"), "M1", "Pro1" },
                    { new Guid("a4ca47bb-1b48-4eed-ad30-4a41352d4834"), "M2", "Pro2" },
                    { new Guid("98971972-7b24-4c7c-807f-78414bf5e52f"), "M3", "Pro3" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { new Guid("76ddb584-af5e-4b9e-9498-01295496fdd2"), new Guid("1f14e8e7-3900-43a4-980b-6d46e9a301a5") });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { new Guid("043074b5-16ec-4112-b2e9-331ad5ad1f83"), new Guid("a4ca47bb-1b48-4eed-ad30-4a41352d4834") });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { new Guid("3408896e-2c5c-4285-899b-3d760002ccfa"), new Guid("98971972-7b24-4c7c-807f-78414bf5e52f") });
        }
    }
}
