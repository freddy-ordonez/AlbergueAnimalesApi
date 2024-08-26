using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlbergueAnimalesRescatadosApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangesConfigurationAnimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Animals",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 20);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                column: "State",
                value: "ADOPCION");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("a3b6c8d7-0d29-4b08-873d-378d6ab9c6a2"),
                column: "State",
                value: "ADOPCION");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("d3c3d7d2-5b76-4eaf-bd9b-5c7d0a9e8b9e"),
                column: "State",
                value: "ADOPCION");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("e2a4f8b3-1c6b-4d77-8a6c-8b012d5c1d7f"),
                column: "State",
                value: "ADOPCION");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("f1f1e2e3-9c7e-4a0d-8b47-cce9b4a915b6"),
                column: "State",
                value: "ADOPCION");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "Animals",
                type: "int",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                column: "State",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("a3b6c8d7-0d29-4b08-873d-378d6ab9c6a2"),
                column: "State",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("d3c3d7d2-5b76-4eaf-bd9b-5c7d0a9e8b9e"),
                column: "State",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("e2a4f8b3-1c6b-4d77-8a6c-8b012d5c1d7f"),
                column: "State",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("f1f1e2e3-9c7e-4a0d-8b47-cce9b4a915b6"),
                column: "State",
                value: 2);
        }
    }
}
