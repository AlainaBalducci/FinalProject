using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityTest.Migrations
{
    public partial class userMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b7a5435c-8abd-4768-ac35-d527dcf15e6b", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c81d2f70-66de-48de-bfff-a6d22e10640c", "2", "User", "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7a5435c-8abd-4768-ac35-d527dcf15e6b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c81d2f70-66de-48de-bfff-a6d22e10640c");
        }
    }
}
