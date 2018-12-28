using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.EF.Migrations
{
    public partial class ScientificArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Journal",
                table: "ScientificArticle",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ScientificArticle",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Journal",
                table: "ScientificArticle");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "ScientificArticle");
        }
    }
}
