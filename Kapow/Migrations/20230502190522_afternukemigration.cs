using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kapow.Migrations
{
    public partial class afternukemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35892bc1-0b4b-4e61-8dba-e970b331cb76");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "504c4b41-716c-4d7f-a423-1ce19ae9553d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3d014549-7470-4ec4-80a1-f50d1111343f", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9adf09a8-65e4-4064-b576-9da1ba0d8128", "2", "User", "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d014549-7470-4ec4-80a1-f50d1111343f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9adf09a8-65e4-4064-b576-9da1ba0d8128");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "35892bc1-0b4b-4e61-8dba-e970b331cb76", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "504c4b41-716c-4d7f-a423-1ce19ae9553d", "2", "User", "User" });
        }
    }
}
