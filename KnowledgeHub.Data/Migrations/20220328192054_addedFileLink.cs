using Microsoft.EntityFrameworkCore.Migrations;

namespace KnowledgeHub.Data.Migrations
{
    public partial class addedFileLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "file",
                table: "DataContent",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "file",
                table: "DataContent");
        }
    }
}
