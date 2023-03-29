using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatApp.Migrations
{
    public partial class UpdateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "ID", "Avatar", "CreateAt", "Password", "Username" },
                values: new object[] { 1, "female.png", "29/03/2023", "123456", "hungphu" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "ID", "Avatar", "CreateAt", "Password", "Username" },
                values: new object[] { 2, "female.png", "29/03/2023", "123456", "kaiz0402" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
