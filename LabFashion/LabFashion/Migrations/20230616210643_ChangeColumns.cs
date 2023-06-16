using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabFashion.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SystemStatus",
                table: "People",
                newName: "SystemStatusU");

            migrationBuilder.RenameColumn(
                name: "SystemStatus",
                table: "Collections",
                newName: "SystemStatusC");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "People",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);            

            migrationBuilder.CreateIndex(
                name: "IX_People_Email",
                table: "People",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_People_Email",
                table: "People");

            migrationBuilder.RenameColumn(
                name: "SystemStatusU",
                table: "People",
                newName: "SystemStatus");

            migrationBuilder.RenameColumn(
                name: "SystemStatusC",
                table: "Collections",
                newName: "SystemStatus");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "People",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);            
        }
    }
}
