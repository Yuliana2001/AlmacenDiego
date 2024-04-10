using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace pruebaAlmacen.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "134b1b55-a40f-42e1-8372-054313fa80ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f7e33b0-44b3-4a48-9a32-522986b0c5df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9955279d-c6bc-4653-87e0-b1c036cfe585");

            migrationBuilder.AddColumn<int>(
                name: "Cedula",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3c1f1a88-d8bd-48a9-a571-d6a52780ec21", null, "admin", "admin" },
                    { "8b2386bf-6b8a-4b54-8773-6bf5def11eb3", null, "client", "client" },
                    { "e8de83f7-001a-43dd-9749-65877117412d", null, "seller", "seller" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c1f1a88-d8bd-48a9-a571-d6a52780ec21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b2386bf-6b8a-4b54-8773-6bf5def11eb3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8de83f7-001a-43dd-9749-65877117412d");

            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "134b1b55-a40f-42e1-8372-054313fa80ef", null, "admin", "admin" },
                    { "8f7e33b0-44b3-4a48-9a32-522986b0c5df", null, "seller", "seller" },
                    { "9955279d-c6bc-4653-87e0-b1c036cfe585", null, "client", "client" }
                });
        }
    }
}
