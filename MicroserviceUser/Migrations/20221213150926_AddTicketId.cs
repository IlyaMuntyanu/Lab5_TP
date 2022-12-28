using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroserviceUser.Migrations
{
    public partial class AddTicketId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketID",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketID",
                table: "Users");
        }
    }
}
