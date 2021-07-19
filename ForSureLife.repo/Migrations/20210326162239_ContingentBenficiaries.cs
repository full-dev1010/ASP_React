using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ForSureLife.repo.Migrations
{
    public partial class ContingentBenficiaries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContingentName",
                table: "ApplicationInfo");

            migrationBuilder.DropColumn(
                name: "Relationship",
                table: "ApplicationInfo");

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationId1",
                table: "FamilyOrBeneficiary",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FamilyOrBeneficiary_ApplicationId1",
                table: "FamilyOrBeneficiary",
                column: "ApplicationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyOrBeneficiary_Application_ApplicationId1",
                table: "FamilyOrBeneficiary",
                column: "ApplicationId1",
                principalTable: "Application",
                principalColumn: "ApplicationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyOrBeneficiary_Application_ApplicationId1",
                table: "FamilyOrBeneficiary");

            migrationBuilder.DropIndex(
                name: "IX_FamilyOrBeneficiary_ApplicationId1",
                table: "FamilyOrBeneficiary");

            migrationBuilder.DropColumn(
                name: "ApplicationId1",
                table: "FamilyOrBeneficiary");

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
    }
}
