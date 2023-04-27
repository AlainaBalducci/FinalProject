using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kapow.Migrations
{
    public partial class identityMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_FoodTags_FoodTagId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Locations_LocationId",
                table: "Restaurants");

            migrationBuilder.DropTable(
                name: "FoodTags");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_LocationId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Locations_FoodTagId",
                table: "Locations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60493ff2-5bd5-4115-8601-16f7d588e3b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2f0c903-4b77-43d8-85b2-37cbdac96e32");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "FoodTagId",
                table: "Locations");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Restaurants",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5c510c4d-5852-4bda-a68b-9868c057e5eb", "2", "User", "User" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "840f5bf4-1249-4044-8c90-ce30ccf636e9", "1", "Admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c510c4d-5852-4bda-a68b-9868c057e5eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "840f5bf4-1249-4044-8c90-ce30ccf636e9");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Restaurants");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Restaurants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FoodTagId",
                table: "Locations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FoodTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RestaurantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodTags_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "60493ff2-5bd5-4115-8601-16f7d588e3b5", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a2f0c903-4b77-43d8-85b2-37cbdac96e32", "2", "User", "User" });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_LocationId",
                table: "Restaurants",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_FoodTagId",
                table: "Locations",
                column: "FoodTagId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodTags_RestaurantId",
                table: "FoodTags",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_FoodTags_FoodTagId",
                table: "Locations",
                column: "FoodTagId",
                principalTable: "FoodTags",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Locations_LocationId",
                table: "Restaurants",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }
    }
}
