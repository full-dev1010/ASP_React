using Microsoft.EntityFrameworkCore.Migrations;

namespace ForSureLife.repo.Migrations
{
    public partial class AAFinalExpenseAddFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PremiumType",
                table: "AmAmFinalExpense",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "SelectedBenefitAmount",
                table: "AmAmFinalExpense",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SelectedMonthlyRate",
                table: "AmAmFinalExpense",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PremiumType",
                table: "AmAmFinalExpense");

            migrationBuilder.DropColumn(
                name: "SelectedBenefitAmount",
                table: "AmAmFinalExpense");

            migrationBuilder.DropColumn(
                name: "SelectedMonthlyRate",
                table: "AmAmFinalExpense");
        }
    }
}
