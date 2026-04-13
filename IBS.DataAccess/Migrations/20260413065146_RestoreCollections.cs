using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IBS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RestoreCollections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_mmsi_billings_customers_customer_id",
                table: "mmsi_billings");

            migrationBuilder.DropForeignKey(
                name: "fk_mmsi_billings_mmsi_collections_collection_id",
                table: "mmsi_billings");

            migrationBuilder.DropForeignKey(
                name: "fk_mmsi_billings_mmsi_ports_port_id",
                table: "mmsi_billings");

            migrationBuilder.DropForeignKey(
                name: "fk_mmsi_billings_mmsi_principals_principal_id",
                table: "mmsi_billings");

            migrationBuilder.DropForeignKey(
                name: "fk_mmsi_billings_mmsi_terminals_terminal_id",
                table: "mmsi_billings");

            migrationBuilder.DropForeignKey(
                name: "fk_mmsi_billings_mmsi_vessels_vessel_id",
                table: "mmsi_billings");

            migrationBuilder.DropForeignKey(
                name: "fk_mmsi_dispatch_tickets_mmsi_billings_billing_id",
                table: "mmsi_dispatch_tickets");

            migrationBuilder.DropPrimaryKey(
                name: "pk_mmsi_billings",
                table: "mmsi_billings");

            migrationBuilder.RenameTable(
                name: "mmsi_billings",
                newName: "billings");

            migrationBuilder.RenameIndex(
                name: "ix_mmsi_billings_vessel_id",
                table: "billings",
                newName: "ix_billings_vessel_id");

            migrationBuilder.RenameIndex(
                name: "ix_mmsi_billings_terminal_id",
                table: "billings",
                newName: "ix_billings_terminal_id");

            migrationBuilder.RenameIndex(
                name: "ix_mmsi_billings_principal_id",
                table: "billings",
                newName: "ix_billings_principal_id");

            migrationBuilder.RenameIndex(
                name: "ix_mmsi_billings_port_id",
                table: "billings",
                newName: "ix_billings_port_id");

            migrationBuilder.RenameIndex(
                name: "ix_mmsi_billings_mmsi_billing_number_company",
                table: "billings",
                newName: "ix_billings_mmsi_billing_number_company");

            migrationBuilder.RenameIndex(
                name: "ix_mmsi_billings_date",
                table: "billings",
                newName: "ix_billings_date");

            migrationBuilder.RenameIndex(
                name: "ix_mmsi_billings_customer_id",
                table: "billings",
                newName: "ix_billings_customer_id");

            migrationBuilder.RenameIndex(
                name: "ix_mmsi_billings_collection_id",
                table: "billings",
                newName: "ix_billings_collection_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_billings",
                table: "billings",
                column: "mmsi_billing_id");

            migrationBuilder.AddForeignKey(
                name: "fk_billings_customers_customer_id",
                table: "billings",
                column: "customer_id",
                principalTable: "customers",
                principalColumn: "customer_id");

            migrationBuilder.AddForeignKey(
                name: "fk_billings_mmsi_collections_collection_id",
                table: "billings",
                column: "collection_id",
                principalTable: "mmsi_collections",
                principalColumn: "mmsi_collection_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_billings_mmsi_ports_port_id",
                table: "billings",
                column: "port_id",
                principalTable: "mmsi_ports",
                principalColumn: "port_id");

            migrationBuilder.AddForeignKey(
                name: "fk_billings_mmsi_principals_principal_id",
                table: "billings",
                column: "principal_id",
                principalTable: "mmsi_principals",
                principalColumn: "principal_id");

            migrationBuilder.AddForeignKey(
                name: "fk_billings_mmsi_terminals_terminal_id",
                table: "billings",
                column: "terminal_id",
                principalTable: "mmsi_terminals",
                principalColumn: "terminal_id");

            migrationBuilder.AddForeignKey(
                name: "fk_billings_mmsi_vessels_vessel_id",
                table: "billings",
                column: "vessel_id",
                principalTable: "mmsi_vessels",
                principalColumn: "vessel_id");

            migrationBuilder.AddForeignKey(
                name: "fk_mmsi_dispatch_tickets_billings_billing_id",
                table: "mmsi_dispatch_tickets",
                column: "billing_id",
                principalTable: "billings",
                principalColumn: "mmsi_billing_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_billings_customers_customer_id",
                table: "billings");

            migrationBuilder.DropForeignKey(
                name: "fk_billings_mmsi_collections_collection_id",
                table: "billings");

            migrationBuilder.DropForeignKey(
                name: "fk_billings_mmsi_ports_port_id",
                table: "billings");

            migrationBuilder.DropForeignKey(
                name: "fk_billings_mmsi_principals_principal_id",
                table: "billings");

            migrationBuilder.DropForeignKey(
                name: "fk_billings_mmsi_terminals_terminal_id",
                table: "billings");

            migrationBuilder.DropForeignKey(
                name: "fk_billings_mmsi_vessels_vessel_id",
                table: "billings");

            migrationBuilder.DropForeignKey(
                name: "fk_mmsi_dispatch_tickets_billings_billing_id",
                table: "mmsi_dispatch_tickets");

            migrationBuilder.DropPrimaryKey(
                name: "pk_billings",
                table: "billings");

            migrationBuilder.RenameTable(
                name: "billings",
                newName: "mmsi_billings");

            migrationBuilder.RenameIndex(
                name: "ix_billings_vessel_id",
                table: "mmsi_billings",
                newName: "ix_mmsi_billings_vessel_id");

            migrationBuilder.RenameIndex(
                name: "ix_billings_terminal_id",
                table: "mmsi_billings",
                newName: "ix_mmsi_billings_terminal_id");

            migrationBuilder.RenameIndex(
                name: "ix_billings_principal_id",
                table: "mmsi_billings",
                newName: "ix_mmsi_billings_principal_id");

            migrationBuilder.RenameIndex(
                name: "ix_billings_port_id",
                table: "mmsi_billings",
                newName: "ix_mmsi_billings_port_id");

            migrationBuilder.RenameIndex(
                name: "ix_billings_mmsi_billing_number_company",
                table: "mmsi_billings",
                newName: "ix_mmsi_billings_mmsi_billing_number_company");

            migrationBuilder.RenameIndex(
                name: "ix_billings_date",
                table: "mmsi_billings",
                newName: "ix_mmsi_billings_date");

            migrationBuilder.RenameIndex(
                name: "ix_billings_customer_id",
                table: "mmsi_billings",
                newName: "ix_mmsi_billings_customer_id");

            migrationBuilder.RenameIndex(
                name: "ix_billings_collection_id",
                table: "mmsi_billings",
                newName: "ix_mmsi_billings_collection_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_mmsi_billings",
                table: "mmsi_billings",
                column: "mmsi_billing_id");

            migrationBuilder.AddForeignKey(
                name: "fk_mmsi_billings_customers_customer_id",
                table: "mmsi_billings",
                column: "customer_id",
                principalTable: "customers",
                principalColumn: "customer_id");

            migrationBuilder.AddForeignKey(
                name: "fk_mmsi_billings_mmsi_collections_collection_id",
                table: "mmsi_billings",
                column: "collection_id",
                principalTable: "mmsi_collections",
                principalColumn: "mmsi_collection_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_mmsi_billings_mmsi_ports_port_id",
                table: "mmsi_billings",
                column: "port_id",
                principalTable: "mmsi_ports",
                principalColumn: "port_id");

            migrationBuilder.AddForeignKey(
                name: "fk_mmsi_billings_mmsi_principals_principal_id",
                table: "mmsi_billings",
                column: "principal_id",
                principalTable: "mmsi_principals",
                principalColumn: "principal_id");

            migrationBuilder.AddForeignKey(
                name: "fk_mmsi_billings_mmsi_terminals_terminal_id",
                table: "mmsi_billings",
                column: "terminal_id",
                principalTable: "mmsi_terminals",
                principalColumn: "terminal_id");

            migrationBuilder.AddForeignKey(
                name: "fk_mmsi_billings_mmsi_vessels_vessel_id",
                table: "mmsi_billings",
                column: "vessel_id",
                principalTable: "mmsi_vessels",
                principalColumn: "vessel_id");

            migrationBuilder.AddForeignKey(
                name: "fk_mmsi_dispatch_tickets_mmsi_billings_billing_id",
                table: "mmsi_dispatch_tickets",
                column: "billing_id",
                principalTable: "mmsi_billings",
                principalColumn: "mmsi_billing_id");
        }
    }
}
