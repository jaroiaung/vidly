using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vidly.Migrations
{
    /// <inheritdoc />
    public partial class AddSendEmailTester : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SendEmailTesters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PinDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SendEmailTesters", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 10, 22, 12, 20, 9, 563, DateTimeKind.Local).AddTicks(6230), new DateTime(2024, 10, 22, 12, 20, 9, 563, DateTimeKind.Local).AddTicks(6240) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SendEmailTesters");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 10, 18, 14, 43, 18, 301, DateTimeKind.Local).AddTicks(1150), new DateTime(2024, 10, 18, 14, 43, 18, 301, DateTimeKind.Local).AddTicks(1170) });
        }
    }
}
