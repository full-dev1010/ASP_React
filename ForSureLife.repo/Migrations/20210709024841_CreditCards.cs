using Microsoft.EntityFrameworkCore.Migrations;

namespace ForSureLife.repo.Migrations
{
    public partial class CreditCards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreditCardRef",
                table: "PaymentInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentType",
                table: "PaymentInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ImmediateLeadSendToIntegrity",
                table: "Application",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SaleCaputured",
                table: "Application",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditCardRef",
                table: "PaymentInfo");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "PaymentInfo");

            migrationBuilder.DropColumn(
                name: "ImmediateLeadSendToIntegrity",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "SaleCaputured",
                table: "Application");
        }
    }
}
