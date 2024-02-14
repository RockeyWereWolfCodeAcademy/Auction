using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction.DAL.Migrations
{
    public partial class EditedLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ActivityLogs");

            migrationBuilder.AddColumn<string>(
                name: "LogEvent",
                table: "ActivityLogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MessageTemplate",
                table: "ActivityLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Properties",
                table: "ActivityLogs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogEvent",
                table: "ActivityLogs");

            migrationBuilder.DropColumn(
                name: "MessageTemplate",
                table: "ActivityLogs");

            migrationBuilder.DropColumn(
                name: "Properties",
                table: "ActivityLogs");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ActivityLogs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
