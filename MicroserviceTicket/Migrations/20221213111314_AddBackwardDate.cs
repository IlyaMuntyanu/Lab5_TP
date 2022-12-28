using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroserviceTicket.Migrations
{
    public partial class AddBackwardDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BackwardDate",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackwardDate",
                table: "Tickets");
        }
    }
}
