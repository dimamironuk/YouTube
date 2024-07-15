using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YouTube.Migrations
{
    /// <inheritdoc />
    public partial class NewVideo : Migration
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
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfPublication = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "Birthday", "Email", "Name", "Nickname", "Password" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John Doe", "JohnDoe", "123456" },
                    { 2, null, new DateTime(1985, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane Smith", "JaneSmith", "qwerty" },
                    { 3, null, new DateTime(1988, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.brown@example.com", "Michael Brown", "MichaelBrown", "221002" },
                    { 4, null, new DateTime(1995, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "emily.johnson@example.com", "Emily Johnson", "EmilyJohnson", "school1" },
                    { 5, null, new DateTime(1992, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "william.wilson@example.com", "William Wilson", "WilliamWilson", "412512" },
                    { 6, null, new DateTime(1987, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "olivia.davis@example.com", "Olivia Davis", "OliviaDavis", "satq24" },
                    { 7, null, new DateTime(1993, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "james.miller@example.com", "James Miller", "JamesMiller", "rq24ar" },
                    { 8, null, new DateTime(1983, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "sophia.martinez@example.com", "Sophia Martinez", "SophiaMartinez", "52356" },
                    { 9, null, new DateTime(1991, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "benjamin.garcia@example.com", "Benjamin Garcia", "BenjaminGarcia", "rEe24" },
                    { 10, null, new DateTime(1989, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "isabella.lopez@example.com", "Isabella Lopez", "IsabellaLopez", "rw0wrq" }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "DateOfPublication", "Description", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "A beginner's guide to C#", "Introduction to C#", 1 },
                    { 2, new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deep dive into Java programming.", "Advanced Java Programming", 2 },
                    { 3, new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Everything you need to know about JavaScript.", "JavaScript Essentials", 2 },
                    { 4, new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Using Python for data analysis and machine learning.", "Python for Data Science", 5 },
                    { 5, new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Building modern web applications with React.", "Web Development with React", 1 },
                    { 6, new DateTime(2023, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn how to manage databases using SQL.", "Database Management with SQL", 6 },
                    { 7, new DateTime(2023, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "An introduction to cybersecurity principles.", "Cybersecurity Basics", 7 },
                    { 8, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Creating mobile applications for Android and iOS.", "Mobile App Development", 8 },
                    { 9, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Understanding cloud computing with AWS.", "Cloud Computing with AWS", 5 },
                    { 10, new DateTime(2024, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Exploring AI and machine learning concepts.", "Artificial Intelligence and Machine Learning", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Videos_UserId",
                table: "Videos",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
