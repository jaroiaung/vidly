using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vidly.Migrations
{
    /// <inheritdoc />
    public partial class AddNotMapped : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 10, 22, 13, 51, 4, 109, DateTimeKind.Local).AddTicks(1130), new DateTime(2024, 10, 22, 13, 51, 4, 109, DateTimeKind.Local).AddTicks(1150) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 10, 22, 12, 20, 9, 563, DateTimeKind.Local).AddTicks(6230), new DateTime(2024, 10, 22, 12, 20, 9, 563, DateTimeKind.Local).AddTicks(6240) });
        }
    }
}
