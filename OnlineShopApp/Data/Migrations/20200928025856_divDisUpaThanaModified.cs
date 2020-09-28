using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShopApp.Data.Migrations
{
    public partial class divDisUpaThanaModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ThanaOrUpazila",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PostOffice",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "District",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ThanaOrUpazila");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PostOffice");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "District");
        }
    }
}
