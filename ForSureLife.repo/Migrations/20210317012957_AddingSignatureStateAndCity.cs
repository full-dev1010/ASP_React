using Microsoft.EntityFrameworkCore.Migrations;

namespace ForSureLife.repo.Migrations
{
    public partial class AddingSignatureStateAndCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SignatureLocation",
                table: "AmAmFinalExpense",
                newName: "SignatureLocationState");

            migrationBuilder.AddColumn<string>(
                name: "SignatureLocationCity",
                table: "AmAmFinalExpense",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SignatureLocationCity",
                table: "AmAmFinalExpense");

            migrationBuilder.RenameColumn(
                name: "SignatureLocationState",
                table: "AmAmFinalExpense",
                newName: "SignatureLocation");
        }
    }
}
