using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroserviceTicket.Migrations
{
    public partial class InitTicketDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeparturePoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransferPoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArrivalPoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartureDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Flight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TravelTime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
