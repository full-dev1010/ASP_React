using Microsoft.EntityFrameworkCore.Migrations;

namespace ForSureLife.repo.Migrations
{
    public partial class FileNumberSequence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "AccountNumber",
                table: "PaymentInfo",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FileNumber",
                table: "AmAmFinalExpense",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql("CREATE SEQUENCE app_file_counter" +
                " AS INT" +
                " START WITH 100000" +
                " INCREMENT BY 1;"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileNumber",
                table: "AmAmFinalExpense");

            migrationBuilder.AlterColumn<int>(
                name: "AccountNumber",
                table: "PaymentInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
