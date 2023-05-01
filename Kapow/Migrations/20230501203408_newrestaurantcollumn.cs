using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kapow.Migrations
{
    public partial class newrestaurantcollumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Restaurant1",
                table: "Profiles",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Restaurant2",
                table: "Profiles",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Restaurant3",
                table: "Profiles",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "629c2a69-fde8-4437-8074-221714379ede", "2", "User", "User" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "da0f0651-0202-42cb-a96e-7c25ead8fb9a", "1", "Admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "629c2a69-fde8-4437-8074-221714379ede");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da0f0651-0202-42cb-a96e-7c25ead8fb9a");

            migrationBuilder.DropColumn(
                name: "Restaurant1",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Restaurant2",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Restaurant3",
                table: "Profiles");

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
    }
}
