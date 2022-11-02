using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApp.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Readers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReaderId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Readers_ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "Readers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "OrderId", "Title" },
                values: new object[,]
                {
                    { 1, "Роберт Шекли", 0, "Секретное оружие" },
                    { 2, "Фрэнк Герберт", 0, "Дюна" },
                    { 3, "Рэй Брэдбери", 0, "451 градус по фаренгейту" },
                    { 4, "Борис Стругацкий", 0, "Пикник на обочине" },
                    { 5, "Дмитрий Глуховский", 0, "Метро 2033" }
                });

            migrationBuilder.InsertData(
                table: "Readers",
                columns: new[] { "Id", "Firstname", "Lastname" },
                values: new object[,]
                {
                    { 1, "Антон", "Давидович" },
                    { 2, "Филипп", "Приходько" },
                    { 3, "Вахид", "Уходько" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "BookId", "ExpireDate", "OrderDate", "ReaderId" },
                values: new object[] { 1, 2, new DateTime(2022, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BookId",
                table: "Orders",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ReaderId",
                table: "Orders",
                column: "ReaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Readers");
        }
    }
}
