using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vidly.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToShoppingCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 10, 18, 14, 43, 18, 301, DateTimeKind.Local).AddTicks(1150), new DateTime(2024, 10, 18, 14, 43, 18, 301, DateTimeKind.Local).AddTicks(1170) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 10, 13, 18, 40, 12, 175, DateTimeKind.Local).AddTicks(1980), new DateTime(2024, 10, 13, 18, 40, 12, 175, DateTimeKind.Local).AddTicks(2000) });
        }
    }
}
