using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkDev.DatingApp.Presistence.Migrations
{
    public partial class updatePhotosEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoUrl",
                table: "Photo",
                newName: "Url");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Photo",
                newName: "PhotoUrl");
        }
    }
}
