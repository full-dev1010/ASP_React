using Microsoft.EntityFrameworkCore.Migrations;

namespace ForSureLife.repo.Migrations
{
    public partial class LeadEligibleAndHealthAnswered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HealthQuestionsAnswered",
                table: "Lead",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEligible",
                table: "Lead",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HealthQuestionsAnswered",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "IsEligible",
                table: "Lead");
        }
    }
}
