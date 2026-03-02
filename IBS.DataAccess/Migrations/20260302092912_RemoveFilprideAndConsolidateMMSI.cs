using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IBS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFilprideAndConsolidateMMSI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_filpride",
                table: "customers");

            migrationBuilder.RenameColumn(
                name: "is_filpride",
                table: "suppliers",
                newName: "is_mmsi");

            migrationBuilder.RenameColumn(
                name: "is_filpride",
                table: "services",
                newName: "is_mmsi");

            migrationBuilder.RenameColumn(
                name: "is_filpride",
                table: "pick_up_points",
                newName: "is_mmsi");

            migrationBuilder.RenameColumn(
                name: "is_filpride",
                table: "bank_accounts",
                newName: "is_mmsi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "is_mmsi",
                table: "suppliers",
                newName: "is_filpride");

            migrationBuilder.RenameColumn(
                name: "is_mmsi",
                table: "services",
                newName: "is_filpride");

            migrationBuilder.RenameColumn(
                name: "is_mmsi",
                table: "pick_up_points",
                newName: "is_filpride");

            migrationBuilder.RenameColumn(
                name: "is_mmsi",
                table: "bank_accounts",
                newName: "is_filpride");

            migrationBuilder.AddColumn<bool>(
                name: "is_filpride",
                table: "customers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
