using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFStore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
