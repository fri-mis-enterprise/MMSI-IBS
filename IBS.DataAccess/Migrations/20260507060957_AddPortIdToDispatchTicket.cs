using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IBS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPortIdToDispatchTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "port_id",
                table: "mmsi_dispatch_tickets",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_mmsi_dispatch_tickets_port_id",
                table: "mmsi_dispatch_tickets",
                column: "port_id");

            migrationBuilder.AddForeignKey(
                name: "fk_mmsi_dispatch_tickets_mmsi_ports_port_id",
                table: "mmsi_dispatch_tickets",
                column: "port_id",
                principalTable: "mmsi_ports",
                principalColumn: "port_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_mmsi_dispatch_tickets_mmsi_ports_port_id",
                table: "mmsi_dispatch_tickets");

            migrationBuilder.DropIndex(
                name: "ix_mmsi_dispatch_tickets_port_id",
                table: "mmsi_dispatch_tickets");

            migrationBuilder.DropColumn(
                name: "port_id",
                table: "mmsi_dispatch_tickets");
        }
    }
}
