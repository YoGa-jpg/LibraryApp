using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApp.Migrations
{
    public partial class ConfiguredPt1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "OrderId", "Title" },
                values: new object[,]
                {
                    { 1, "Роберт Шекли", null, "Секретное оружие" },
                    { 2, "Фрэнк Герберт", 2, "Дюна" },
                    { 3, "Рэй Брэдбери", null, "451 градус по фаренгейту" },
                    { 4, "Борис Стругацкий", null, "Пикник на обочине" },
                    { 5, "Дмитрий Глуховский", null, "Метро 2033" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "OrderId", "Title" },
                values: new object[,]
                {
                    { 1, "Роберт Шекли", null, "Секретное оружие" },
                    { 2, "Фрэнк Герберт", 2, "Дюна" },
                    { 3, "Рэй Брэдбери", null, "451 градус по фаренгейту" },
                    { 4, "Борис Стругацкий", null, "Пикник на обочине" },
                    { 5, "Дмитрий Глуховский", null, "Метро 2033" }
                });
        }
    }
}
