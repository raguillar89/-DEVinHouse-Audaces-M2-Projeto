using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabFashion.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnsName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SystemStatusU",
                table: "People",
                newName: "SystemStatus");

            migrationBuilder.RenameColumn(
                name: "SystemStatusC",
                table: "Collections",
                newName: "SystemStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SystemStatus",
                table: "People",
                newName: "SystemStatusU");

            migrationBuilder.RenameColumn(
                name: "SystemStatus",
                table: "Collections",
                newName: "SystemStatusC");
        }
    }
}
