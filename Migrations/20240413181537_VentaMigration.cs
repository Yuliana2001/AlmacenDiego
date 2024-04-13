using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace pruebaAlmacen.Migrations
{
    /// <inheritdoc />
    public partial class VentaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e43e46b-3b69-42c3-8c6c-a0f81e396b5a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c83cacdc-6f67-47b1-82d1-46bb23f6d224");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f17c864b-8602-4df9-84fc-5585e017c899");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "553ce7de-dd72-44aa-8794-5064c766d2bc", null, "client", "client" },
                    { "633762f7-0592-444a-af47-c3f6eb6589a0", null, "seller", "seller" },
                    { "7252cefb-e14a-420b-b963-9259130ddfd0", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "553ce7de-dd72-44aa-8794-5064c766d2bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "633762f7-0592-444a-af47-c3f6eb6589a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7252cefb-e14a-420b-b963-9259130ddfd0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5e43e46b-3b69-42c3-8c6c-a0f81e396b5a", null, "seller", "seller" },
                    { "c83cacdc-6f67-47b1-82d1-46bb23f6d224", null, "admin", "admin" },
                    { "f17c864b-8602-4df9-84fc-5585e017c899", null, "client", "client" }
                });
        }
    }
}
