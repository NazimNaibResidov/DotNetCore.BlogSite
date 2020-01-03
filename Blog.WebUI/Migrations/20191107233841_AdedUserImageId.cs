using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.WebUI.Migrations
{
    public partial class AdedUserImageId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Images_ImageId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Users",
                newName: "ImageID");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ImageId",
                table: "Users",
                newName: "IX_Users_ImageID");

            migrationBuilder.AlterColumn<int>(
                name: "ImageID",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Images_ImageID",
                table: "Users",
                column: "ImageID",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Images_ImageID",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ImageID",
                table: "Users",
                newName: "ImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ImageID",
                table: "Users",
                newName: "IX_Users_ImageId");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Users",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Images_ImageId",
                table: "Users",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
