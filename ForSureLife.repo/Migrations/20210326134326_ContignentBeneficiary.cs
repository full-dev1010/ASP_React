using Microsoft.EntityFrameworkCore.Migrations;

namespace ForSureLife.repo.Migrations
{
    public partial class ContignentBeneficiary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AcceptAnyPlan",
                table: "ApplicationInfo",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ContingentName",
                table: "ApplicationInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Relationship",
                table: "ApplicationInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptAnyPlan",
                table: "ApplicationInfo");

            migrationBuilder.DropColumn(
                name: "ContingentName",
                table: "ApplicationInfo");

            migrationBuilder.DropColumn(
                name: "Relationship",
                table: "ApplicationInfo");
        }
    }
}
