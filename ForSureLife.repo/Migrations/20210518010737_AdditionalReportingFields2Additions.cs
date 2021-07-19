using Microsoft.EntityFrameworkCore.Migrations;

namespace ForSureLife.repo.Migrations
{
    public partial class AdditionalReportingFields2Additions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PaymentAccountSet",
                table: "Lead",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PaymentDateSet",
                table: "Lead",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReviewPageSeen",
                table: "Lead",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReviewPageSubmit",
                table: "Lead",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SocialSet",
                table: "Lead",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentAccountSet",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "PaymentDateSet",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "ReviewPageSeen",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "ReviewPageSubmit",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "SocialSet",
                table: "Lead");
        }
    }
}
