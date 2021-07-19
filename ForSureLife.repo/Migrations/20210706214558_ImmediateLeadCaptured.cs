using Microsoft.EntityFrameworkCore.Migrations;

namespace ForSureLife.repo.Migrations
{
    public partial class ImmediateLeadCaptured : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ImmediateLeadCaptured",
                table: "Application",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ImmediateLeadEmailed",
                table: "Application",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "QuoteLeadEmailed",
                table: "Application",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImmediateLeadCaptured",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "ImmediateLeadEmailed",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "QuoteLeadEmailed",
                table: "Application");
        }
    }
}
