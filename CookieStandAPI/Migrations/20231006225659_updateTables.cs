using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookieStandAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hour",
                table: "HourlySales");

            migrationBuilder.RenameColumn(
                name: "Sales",
                table: "HourlySales",
                newName: "HourSale");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88131758-c5ab-4271-a9f6-c7936fac5b60", "AQAAAAIAAYagAAAAEGWeefOakj2M3cooV+fm14++XB2JT+ZtkdHB/nRzsOW6ldwBj5pPP/CljZIzbUsemQ==", "c35f17c3-b5e2-4bba-86d7-77d02b07741d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HourSale",
                table: "HourlySales",
                newName: "Sales");

            migrationBuilder.AddColumn<int>(
                name: "Hour",
                table: "HourlySales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "179acf5b-f966-4e49-bab1-14c309632ff5", "AQAAAAIAAYagAAAAEIPNm8vsNXG9m1mCkFCpfsydCoJRnlPP2GR0dfG0HCpZ1FoMrK2kaps2El5fprc1yw==", "c92b4bc9-139c-4605-96ed-0ed9e6ae1b40" });
        }
    }
}
