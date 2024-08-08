using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAvatarUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "AvatarUrl",
                value: "https://www.cnet.com/a/img/resize/20d6844768bd3f5f0df41deee97897423bcaf3c5/hub/2021/11/03/3c2a7d79-770e-4cfa-9847-66b3901fb5d7/c09.jpg?auto=webp&fit=crop&height=1200&width=1200");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "AvatarUrl",
                value: "https://i.pinimg.com/236x/6f/0c/7d/6f0c7dd236a49fef3d2c7ad9def7f87c.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "AvatarUrl",
                value: "https://i.pinimg.com/236x/ef/31/da/ef31da3aac21d75fede9d3ca00b8f14f.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "AvatarUrl",
                value: "https://i.pinimg.com/236x/5b/02/47/5b0247d140ff9659066d61fa63edc79a.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "AvatarUrl",
                value: "https://i.pinimg.com/236x/28/6d/91/286d914fd4f3739e4b063aaf7875a04a.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "AvatarUrl",
                value: "https://i.pinimg.com/236x/b1/d8/db/b1d8dbf9167c52e0615adc13437f07bf.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "AvatarUrl",
                value: "https://i.pinimg.com/236x/f8/32/e9/f832e9eeb044c0724ed38d11a6fc3c52.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "AvatarUrl",
                value: "https://i.pinimg.com/236x/74/a2/9b/74a29b1557ea388218519536143e3eee.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "AvatarUrl",
                value: "https://cdn-0001.qstv.on.epicgames.com/spbduGeODldQXSaWaZ/image/landscape_comp.jpeg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "AvatarUrl",
                value: "https://upload.wikimedia.org/wikipedia/en/thumb/9/96/Meme_Man_on_transparent_background.webp/316px-Meme_Man_on_transparent_background.webp.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "AvatarUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "AvatarUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "AvatarUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "AvatarUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "AvatarUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "AvatarUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "AvatarUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "AvatarUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "AvatarUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "AvatarUrl",
                value: null);
        }
    }
}
