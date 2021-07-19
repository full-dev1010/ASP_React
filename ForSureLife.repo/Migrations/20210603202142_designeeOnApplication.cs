using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ForSureLife.repo.Migrations
{
    public partial class designeeOnApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DesigneeId",
                table: "Application",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Designee",
                columns: table => new
                {
                    DesigneeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Signed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designee", x => x.DesigneeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Application_DesigneeId",
                table: "Application",
                column: "DesigneeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Designee_DesigneeId",
                table: "Application",
                column: "DesigneeId",
                principalTable: "Designee",
                principalColumn: "DesigneeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_Designee_DesigneeId",
                table: "Application");

            migrationBuilder.DropTable(
                name: "Designee");

            migrationBuilder.DropIndex(
                name: "IX_Application_DesigneeId",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "DesigneeId",
                table: "Application");
        }
    }
}
