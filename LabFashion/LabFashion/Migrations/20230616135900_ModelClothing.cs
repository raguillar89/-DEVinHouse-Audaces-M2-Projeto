using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabFashion.Migrations
{
    /// <inheritdoc />
    public partial class ModelClothing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    IdModel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeModel = table.Column<int>(type: "int", nullable: false),
                    LayoutModel = table.Column<int>(type: "int", nullable: false),
                    IdCollection = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.IdModel);
                    table.ForeignKey(
                        name: "FK_Models_Collections_IdCollection",
                        column: x => x.IdCollection,
                        principalTable: "Collections",
                        principalColumn: "IdCollection",
                        onDelete: ReferentialAction.Cascade);
                });            

            migrationBuilder.CreateIndex(
                name: "IX_Models_IdCollection",
                table: "Models",
                column: "IdCollection");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Models");
        }
    }
}
