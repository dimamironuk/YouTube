using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class NewTableVideos : Migration
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
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviewUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                columns: new[] { "Id", "DateOfPublication", "Description", "PreviewUrl", "Title", "UserId", "VideoUrl" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "A beginner's guide to C#", "https://static-cse.canva.com/blob/1633154/1600w-wK95f3XNRaM.53b81e59.jpg", "Introduction to C#", 1, "https://www.microsoft.com/en-us/videoplayer-nocookie/embed/RWe8JU?pid=ocpVideo1&maskLevel=20&market=en-us" },
                    { 2, new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deep dive into Java programming.", "https://marketplace.canva.com/EAFf5rfnPgA/1/0/1600w/canva-blue-modern-eye-catching-vlog-youtube-thumbnail-LEcp-BYepDU.jpg", "Advanced Java Programming", 2, "https://www.microsoft.com/en-us/videoplayer-nocookie/embed/RWe8JU?pid=ocpVideo1&maskLevel=20&market=en-us" },
                    { 3, new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Everything you need to know about JavaScript.", "https://i0.wp.com/i.pinimg.com/originals/d4/94/76/d49476e6169ae02dd0eea882b1443586.jpg?resize=160,120", "JavaScript Essentials", 2, "https://www.microsoft.com/en-us/videoplayer-nocookie/embed/RWe8JU?pid=ocpVideo1&maskLevel=20&market=en-us" },
                    { 4, new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Using Python for data analysis and machine learning.", "https://fiverr-res.cloudinary.com/images/t_main1,q_auto,f_auto,q_auto,f_auto/gigs/125342479/original/7b112c248eb522d29016e1cca95a7ccd9cf50d6f/design-eye-catchy-youtube-thumbnail-in-2-hours.jpg", "Python for Data Science", 5, "https://www.microsoft.com/en-us/videoplayer-nocookie/embed/RWe8JU?pid=ocpVideo1&maskLevel=20&market=en-us" },
                    { 5, new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Building modern web applications with React.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSB-bmx9MFjFvH0p1MZzMU8fwYPAO-mzUhZM6di1tsXrzWfSdXyvJyr1Ry503HmyDnt8ns&usqp=CAU", "Web Development with React", 1, "https://www.microsoft.com/en-us/videoplayer-nocookie/embed/RWe8JU?pid=ocpVideo1&maskLevel=20&market=en-us" },
                    { 6, new DateTime(2023, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn how to manage databases using SQL.", "https://fiverr-res.cloudinary.com/images/t_main1,q_auto,f_auto,q_auto,f_auto/gigs/163993931/original/bea1055dbfd13392ad4d291eae22fb9cd3a84484/design-amazing-youtube-thumbnail-in-3-hours.jpg", "Database Management with SQL", 6, "https://www.microsoft.com/en-us/videoplayer-nocookie/embed/RWe8JU?pid=ocpVideo1&maskLevel=20&market=en-us" },
                    { 7, new DateTime(2023, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "An introduction to cybersecurity principles.", "https://i0.wp.com/ytimg.googleusercontent.com/vi/pbdwbva4-WI/maxresdefault.jpg?resize=160,120", "Cybersecurity Basics", 7, "https://www.microsoft.com/en-us/videoplayer-nocookie/embed/RWe8JU?pid=ocpVideo1&maskLevel=20&market=en-us" },
                    { 8, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Creating mobile applications for Android and iOS.", "https://i0.wp.com/ytimg.googleusercontent.com/vi/eftWmNzWbxk/maxresdefault.jpg?resize=160,120", "Mobile App Development", 8, "https://www.microsoft.com/en-us/videoplayer-nocookie/embed/RWe8JU?pid=ocpVideo1&maskLevel=20&market=en-us" },
                    { 9, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Understanding cloud computing with AWS.", "https://i0.wp.com/ytimg.googleusercontent.com/vi/8YbZuaBP9B8/maxresdefault.jpg?resize=160,120", "Cloud Computing with AWS", 5, "https://www.microsoft.com/en-us/videoplayer-nocookie/embed/RWe8JU?pid=ocpVideo1&maskLevel=20&market=en-us" },
                    { 10, new DateTime(2024, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Exploring AI and machine learning concepts.", "https://i0.wp.com/ytimg.googleusercontent.com/vi/CJ3hfxxlF2Q/maxresdefault.jpg?resize=160,120", "Artificial Intelligence and Machine Learning", 10, "https://www.microsoft.com/en-us/videoplayer-nocookie/embed/RWe8JU?pid=ocpVideo1&maskLevel=20&market=en-us" }
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
