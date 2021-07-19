using Microsoft.EntityFrameworkCore.Migrations;

namespace ForSureLife.repo.Migrations
{
    public partial class UpdatingDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DoctorCity",
                table: "ApplicationInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoctorName",
                table: "ApplicationInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoctorPhone",
                table: "ApplicationInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorState",
                table: "ApplicationInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorCity",
                table: "ApplicationInfo");

            migrationBuilder.DropColumn(
                name: "DoctorName",
                table: "ApplicationInfo");

            migrationBuilder.DropColumn(
                name: "DoctorPhone",
                table: "ApplicationInfo");

            migrationBuilder.DropColumn(
                name: "DoctorState",
                table: "ApplicationInfo");
        }
    }
}
