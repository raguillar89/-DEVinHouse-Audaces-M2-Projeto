using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LabFashion.Migrations
{
    /// <inheritdoc />
    public partial class PersonUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    IdPerson = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamePerson = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    GenrePerson = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    BirthDatePerson = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentPerson = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    PhoneNumberPerson = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeUser = table.Column<int>(type: "int", nullable: true),
                    SystemStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.IdPerson);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "IdPerson", "BirthDatePerson", "Discriminator", "DocumentPerson", "GenrePerson", "NamePerson", "PhoneNumberPerson", "SystemStatus", "TypeUser" },
                values: new object[,]
                {
                    { 1, new DateTime(1989, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "00321456987", "Masculino", "Renan", "12345678900", 1, 1 },
                    { 2, new DateTime(1957, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "7564745756", "Masculino", "José Ricardo", "8679678986", 2, 1 },
                    { 3, new DateTime(1982, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "11111111111", "Masculino", "Eric", "2121121212", 1, 2 },
                    { 4, new DateTime(1991, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "43124321432", "Feminino", "Priscila", "52345432543", 2, 1 },
                    { 5, new DateTime(1953, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "86973535445", "Feminino", "Sonia", "0978096463", 1, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
