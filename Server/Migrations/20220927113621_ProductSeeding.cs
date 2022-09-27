using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrightApp.Server.Migrations
{
    public partial class ProductSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
