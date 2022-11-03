using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrightApp.Server.Migrations
{
    public partial class AddUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bleets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bleets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bleets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bleets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "BleetTitle",
                table: "Bleets",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BleetText",
                table: "Bleets",
                type: "nvarchar(280)",
                maxLength: 280,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "BleetTitle",
                table: "Bleets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "BleetText",
                table: "Bleets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(280)",
                oldMaxLength: 280);

            migrationBuilder.InsertData(
                table: "Bleets",
                columns: new[] { "Id", "BleetText", "BleetTitle", "CreatedAt", "CreatorUsername" },
                values: new object[,]
                {
                    { 1, "Que sera sera", "First Bleet", new DateTime(2022, 9, 27, 11, 36, 21, 61, DateTimeKind.Local).AddTicks(8147), "@stephen_krogger" },
                    { 2, "And so the robots spared humanity", "The doom of mankind", new DateTime(2022, 9, 27, 11, 36, 21, 61, DateTimeKind.Local).AddTicks(8158), "@elon_musk" },
                    { 3, "My Model X is the greatest thing I have ever purchased. Period.", "Sometime in the future...", new DateTime(2022, 9, 27, 11, 36, 21, 61, DateTimeKind.Local).AddTicks(8160), "@stephen_krogger" },
                    { 4, "It cost me everything to balance the world but, the Avengers thwarted my plan by going back in time and killing me. Gamora these are my last words for you, Avenge me!!!", "Avenge me, Gamora!", new DateTime(2022, 9, 27, 11, 36, 21, 61, DateTimeKind.Local).AddTicks(8161), "@probably_thanos" }
                });
        }
    }
}
