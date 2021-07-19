using Microsoft.EntityFrameworkCore.Migrations;

namespace ForSureLife.repo.Migrations
{
    public partial class PremiumInfoOnLead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PremiumType",
                table: "Lead",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "SelectedBenefitAmount",
                table: "Lead",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SelectedMonthlyRate",
                table: "Lead",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PremiumType",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "SelectedBenefitAmount",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "SelectedMonthlyRate",
                table: "Lead");
        }
    }
}
