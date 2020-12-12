using Microsoft.EntityFrameworkCore.Migrations;

namespace WeWriteTogether.Migrations
{
    public partial class FullNameForUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                schema: "AspNetIdentity",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                schema: "AspNetIdentity",
                table: "User");
        }
    }
}
