using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YouTube.Migrations
{
    /// <inheritdoc />
    public partial class Start : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nicname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "Birthday", "Email", "Name", "Nicname" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John Doe", "JohnDoe" },
                    { 2, null, new DateTime(1985, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane Smith", "JaneSmith" },
                    { 3, null, new DateTime(1988, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.brown@example.com", "Michael Brown", "MichaelBrown" },
                    { 4, null, new DateTime(1995, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "emily.johnson@example.com", "Emily Johnson", "EmilyJohnson" },
                    { 5, null, new DateTime(1992, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "william.wilson@example.com", "William Wilson", "WilliamWilson" },
                    { 6, null, new DateTime(1987, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "olivia.davis@example.com", "Olivia Davis", "OliviaDavis" },
                    { 7, null, new DateTime(1993, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "james.miller@example.com", "James Miller", "JamesMiller" },
                    { 8, null, new DateTime(1983, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "sophia.martinez@example.com", "Sophia Martinez", "SophiaMartinez" },
                    { 9, null, new DateTime(1991, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "benjamin.garcia@example.com", "Benjamin Garcia", "BenjaminGarcia" },
                    { 10, null, new DateTime(1989, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "isabella.lopez@example.com", "Isabella Lopez", "IsabellaLopez" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
