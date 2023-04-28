using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kapow.Migrations
{
    public partial class newMigrations1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Profiles_ProfileId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_ProfileId",
                table: "Restaurants");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab3290e1-aad4-4c3f-aa47-fe6a11ff4087");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da2b2304-60b3-439e-96ea-bcf01383a047");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Restaurants");

            migrationBuilder.AddColumn<string>(
                name: "Restaurants",
                table: "Profiles",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1ebee776-1e2a-4bde-931f-6c75c77ab1d9", "2", "User", "User" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5ef2ace5-4cd4-44b3-bb2d-e9a54beae0d1", "1", "Admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ebee776-1e2a-4bde-931f-6c75c77ab1d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ef2ace5-4cd4-44b3-bb2d-e9a54beae0d1");

            migrationBuilder.DropColumn(
                name: "Restaurants",
                table: "Profiles");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Restaurants",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ab3290e1-aad4-4c3f-aa47-fe6a11ff4087", "2", "User", "User" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "da2b2304-60b3-439e-96ea-bcf01383a047", "1", "Admin", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_ProfileId",
                table: "Restaurants",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Profiles_ProfileId",
                table: "Restaurants",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");
        }
    }
}
