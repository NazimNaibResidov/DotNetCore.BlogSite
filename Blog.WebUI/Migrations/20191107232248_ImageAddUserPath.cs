using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.WebUI.Migrations
{
    public partial class ImageAddUserPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserPath",
                table: "Images",
                maxLength: 256,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserPath",
                table: "Images");
        }
    }
}
