using Microsoft.EntityFrameworkCore.Migrations;

namespace ForSureLife.repo.Migrations
{
    public partial class ChangingNameToApplicationstate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "State",
            //    table: "AmAmFinalExpense");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationState",
                table: "AmAmFinalExpense",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationState",
                table: "AmAmFinalExpense");

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "AmAmFinalExpense",
                type: "int",
                nullable: true);
        }
    }
}
