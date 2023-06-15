using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabFashion.Migrations
{
    /// <inheritdoc />
    public partial class ClothingCollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    IdCollection = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCollection = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPerson = table.Column<int>(type: "int", nullable: false),
                    BrandCollection = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BudgetCollection = table.Column<double>(type: "float", nullable: false),
                    ReleaseYearCollection = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    LaunchStation = table.Column<int>(type: "int", nullable: false),
                    SystemStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.IdCollection);
                    table.ForeignKey(
                        name: "FK_Collections_People_IdPerson",
                        column: x => x.IdPerson,
                        principalTable: "People",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collections_IdPerson",
                table: "Collections",
                column: "IdPerson");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Collections");
        }
    }
}
