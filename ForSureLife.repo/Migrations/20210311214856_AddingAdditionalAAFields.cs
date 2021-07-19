using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ForSureLife.repo.Migrations
{
    public partial class AddingAdditionalAAFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientIPAddress",
                table: "AmAmFinalExpense",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SignatureLocation",
                table: "AmAmFinalExpense",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Signed",
                table: "AmAmFinalExpense",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "SignedDate",
                table: "AmAmFinalExpense",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientIPAddress",
                table: "AmAmFinalExpense");

            migrationBuilder.DropColumn(
                name: "SignatureLocation",
                table: "AmAmFinalExpense");

            migrationBuilder.DropColumn(
                name: "Signed",
                table: "AmAmFinalExpense");

            migrationBuilder.DropColumn(
                name: "SignedDate",
                table: "AmAmFinalExpense");
        }
    }
}
