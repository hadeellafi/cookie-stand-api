using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookieStandAPI.Migrations
{
    /// <inheritdoc />
    public partial class login : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b34529b2-6582-4565-b48a-1fce6c77ce38", "AQAAAAIAAYagAAAAEGHhEIIhLiUFwJUUStSjsn8eeTkCHoHJBBa4xr7YRlxglBIjq9ciDi/vrYoig8IfaA==", "255a454d-d1b5-42cb-b816-f49ed8aeb46c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d43c015a-dff3-4764-81e8-9ac022636ecb", "AQAAAAIAAYagAAAAEE+TVBg2ZsSBqNQ+558tJhsl6tXfzTkQfaaLGVL73pu03zvJue5+HpilCVxbFqe83Q==", "e7ad087b-7563-46ac-8212-4962d047440b" });
        }
    }
}
