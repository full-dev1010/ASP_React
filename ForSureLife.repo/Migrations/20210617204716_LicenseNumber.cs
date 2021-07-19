using Microsoft.EntityFrameworkCore.Migrations;

namespace ForSureLife.repo.Migrations
{
    public partial class LicenseNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LicenseNumber",
                table: "AmState",
                type: "nvarchar(max)",
                nullable: true);
            migrationBuilder.Sql("Update AmState Set  LicenseNumber='299789' Where  StateIdEnum = 0");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '0' Where  StateIdEnum = 1");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '6614648' Where  StateIdEnum = 2");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '6614648' Where  StateIdEnum = 3    ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '0' Where  StateIdEnum = 4          ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '309038' Where  StateIdEnum = 5     ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '2713852' Where  StateIdEnum = 6    ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '3001202132' Where  StateIdEnum = 7 ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '0' Where  StateIdEnum = 8          ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = 'E167676' Where  StateIdEnum = 9    ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '758981' Where  StateIdEnum = 10    ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '529647' Where  StateIdEnum = 11    ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '833162' Where  StateIdEnum = 12    ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '6614648' Where  StateIdEnum = 13   ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '583202' Where  StateIdEnum = 14    ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '6614648' Where  StateIdEnum = 15   ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '6614648' Where  StateIdEnum = 16   ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '694230' Where  StateIdEnum = 17    ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '801907' Where  StateIdEnum = 18    ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = 'PRN376729' Where  StateIdEnum = 19 ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '3001202177' Where  StateIdEnum = 20");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '2143421' Where  StateIdEnum = 21   ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '1033499' Where  StateIdEnum = 22   ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '40728927' Where  StateIdEnum = 23  ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '10105180' Where  StateIdEnum = 24  ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '411929' Where  StateIdEnum = 25    ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '0' Where  StateIdEnum = 26         ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '0006614648' Where  StateIdEnum = 27");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '3277972' Where  StateIdEnum = 28   ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '0' Where  StateIdEnum = 29         ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '3001202200' Where  StateIdEnum = 30");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '3001202200' Where  StateIdEnum = 31");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '0' Where  StateIdEnum = 32         ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '6614648' Where  StateIdEnum = 33   ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '0' Where  StateIdEnum = 34         ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '1229894' Where  StateIdEnum = 35   ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '3001202187' Where  StateIdEnum = 36");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '6614648' Where  StateIdEnum = 37   ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '423858' Where  StateIdEnum = 38    ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '2057141' Where  StateIdEnum = 39   ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '6614648' Where  StateIdEnum = 40   ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '0' Where  StateIdEnum = 41         ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '892153' Where  StateIdEnum = 42    ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '1334986' Where  StateIdEnum = 43   ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '303512' Where  StateIdEnum = 44    ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '3651544' Where  StateIdEnum = 45   ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '647195' Where  StateIdEnum = 46    ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '1091949' Where  StateIdEnum = 47   ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '6614648' Where  StateIdEnum = 48   ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '6614648' Where  StateIdEnum = 49   ");
            migrationBuilder.Sql("Update AmState Set  LicenseNumber = '457498' Where  StateIdEnum = 50");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicenseNumber",
                table: "AmState");
        }
    }
}
