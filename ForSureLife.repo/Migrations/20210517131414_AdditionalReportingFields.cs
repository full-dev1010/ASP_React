using Microsoft.EntityFrameworkCore.Migrations;

namespace ForSureLife.repo.Migrations
{
    public partial class AdditionalReportingFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BeneficiarySet",
                table: "Lead",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ClickedEnrolled",
                table: "Lead",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ContactAgent",
                table: "Lead",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "KnockedOut",
                table: "Lead",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LeadCompleted",
                table: "Lead",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "QuoteReceived",
                table: "Lead",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeneficiarySet",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "ClickedEnrolled",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "ContactAgent",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "KnockedOut",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "LeadCompleted",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "QuoteReceived",
                table: "Lead");
        }
    }
}
