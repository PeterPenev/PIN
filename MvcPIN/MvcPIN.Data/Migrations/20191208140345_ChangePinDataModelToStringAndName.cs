using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcPIN.Data.Migrations
{
    public partial class ChangePinDataModelToStringAndName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PinCode",
                table: "PINs");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PINs",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "PINs");

            migrationBuilder.AddColumn<long>(
                name: "PinCode",
                table: "PINs",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
