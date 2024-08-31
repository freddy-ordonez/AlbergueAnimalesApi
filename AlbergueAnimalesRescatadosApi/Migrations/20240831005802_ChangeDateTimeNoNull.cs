using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlbergueAnimalesRescatadosApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDateTimeNoNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                column: "DateDelivery",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("a3b6c8d7-0d29-4b08-873d-378d6ab9c6a2"),
                column: "DateDelivery",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("d3c3d7d2-5b76-4eaf-bd9b-5c7d0a9e8b9e"),
                column: "DateDelivery",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("e2a4f8b3-1c6b-4d77-8a6c-8b012d5c1d7f"),
                column: "DateDelivery",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("f1f1e2e3-9c7e-4a0d-8b47-cce9b4a915b6"),
                column: "DateDelivery",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                column: "DateDelivery",
                value: null);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("a3b6c8d7-0d29-4b08-873d-378d6ab9c6a2"),
                column: "DateDelivery",
                value: null);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("d3c3d7d2-5b76-4eaf-bd9b-5c7d0a9e8b9e"),
                column: "DateDelivery",
                value: null);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("e2a4f8b3-1c6b-4d77-8a6c-8b012d5c1d7f"),
                column: "DateDelivery",
                value: null);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("f1f1e2e3-9c7e-4a0d-8b47-cce9b4a915b6"),
                column: "DateDelivery",
                value: null);
        }
    }
}
