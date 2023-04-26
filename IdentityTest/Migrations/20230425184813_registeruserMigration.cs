using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityTest.Migrations
{
    public partial class registeruserMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7a5435c-8abd-4768-ac35-d527dcf15e6b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c81d2f70-66de-48de-bfff-a6d22e10640c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5c0f5890-722a-479c-9040-216f83e5bbfe", "2", "User", "User" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a476fc9a-d62a-4a44-8ebd-e47a5a0a5cb3", "1", "Admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c0f5890-722a-479c-9040-216f83e5bbfe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a476fc9a-d62a-4a44-8ebd-e47a5a0a5cb3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b7a5435c-8abd-4768-ac35-d527dcf15e6b", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c81d2f70-66de-48de-bfff-a6d22e10640c", "2", "User", "User" });
        }
    }
}
