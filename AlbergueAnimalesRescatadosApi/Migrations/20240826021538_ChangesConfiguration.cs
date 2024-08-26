using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlbergueAnimalesRescatadosApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangesConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Volunteers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Animals",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Adopters",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 20);

            migrationBuilder.UpdateData(
                table: "Adopters",
                keyColumn: "Id",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                column: "State",
                value: "ACTIVO");

            migrationBuilder.UpdateData(
                table: "Adopters",
                keyColumn: "Id",
                keyValue: new Guid("9d6f2d34-a1d7-4d2e-8c12-6b9c8d7e6a1b"),
                column: "State",
                value: "INACTIVO");

            migrationBuilder.UpdateData(
                table: "Adopters",
                keyColumn: "Id",
                keyValue: new Guid("b4a3e2d6-c9d5-4e8b-9f1d-5b9a8c7d2e3a"),
                column: "State",
                value: "ACTIVO");

            migrationBuilder.UpdateData(
                table: "Adopters",
                keyColumn: "Id",
                keyValue: new Guid("d8a5c6f3-b2d1-4a6e-8b9d-3e4f5b6c7d8e"),
                column: "State",
                value: "INACTIVO");

            migrationBuilder.UpdateData(
                table: "Adopters",
                keyColumn: "Id",
                keyValue: new Guid("e7b4a3d5-8f1c-4d6e-9b7e-8c1d9e2f3b4a"),
                column: "State",
                value: "ACTIVO");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                column: "Type",
                value: "Perro");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("a3b6c8d7-0d29-4b08-873d-378d6ab9c6a2"),
                column: "Type",
                value: "Gato");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("d3c3d7d2-5b76-4eaf-bd9b-5c7d0a9e8b9e"),
                column: "Type",
                value: "Perro");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("e2a4f8b3-1c6b-4d77-8a6c-8b012d5c1d7f"),
                column: "Type",
                value: "Perro");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("f1f1e2e3-9c7e-4a0d-8b47-cce9b4a915b6"),
                column: "Type",
                value: "Gato");

            migrationBuilder.UpdateData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                column: "State",
                value: "ACTIVO");

            migrationBuilder.UpdateData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: new Guid("b3e9f0d6-1f2c-4d5e-8a0a-2c3d4e5f6b7a"),
                column: "State",
                value: "INACTIVO");

            migrationBuilder.UpdateData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: new Guid("c7a8d1e5-4f3b-2c6e-9a0d-3e4f5a6b7c8d"),
                column: "State",
                value: "ACTIVO");

            migrationBuilder.UpdateData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: new Guid("d2b4e7c9-3f6a-4e5b-8d0c-1a2b3c4d5e6f"),
                column: "State",
                value: "ACTIVO");

            migrationBuilder.UpdateData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: new Guid("e8f1d3b5-6a7b-4c8e-9f0a-2b3c4d5e6a7d"),
                column: "State",
                value: "ACTIVO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "Volunteers",
                type: "int",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Animals",
                type: "int",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "Adopters",
                type: "int",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.UpdateData(
                table: "Adopters",
                keyColumn: "Id",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                column: "State",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Adopters",
                keyColumn: "Id",
                keyValue: new Guid("9d6f2d34-a1d7-4d2e-8c12-6b9c8d7e6a1b"),
                column: "State",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Adopters",
                keyColumn: "Id",
                keyValue: new Guid("b4a3e2d6-c9d5-4e8b-9f1d-5b9a8c7d2e3a"),
                column: "State",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Adopters",
                keyColumn: "Id",
                keyValue: new Guid("d8a5c6f3-b2d1-4a6e-8b9d-3e4f5b6c7d8e"),
                column: "State",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Adopters",
                keyColumn: "Id",
                keyValue: new Guid("e7b4a3d5-8f1c-4d6e-9b7e-8c1d9e2f3b4a"),
                column: "State",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                column: "Type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("a3b6c8d7-0d29-4b08-873d-378d6ab9c6a2"),
                column: "Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("d3c3d7d2-5b76-4eaf-bd9b-5c7d0a9e8b9e"),
                column: "Type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("e2a4f8b3-1c6b-4d77-8a6c-8b012d5c1d7f"),
                column: "Type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("f1f1e2e3-9c7e-4a0d-8b47-cce9b4a915b6"),
                column: "Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                column: "State",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: new Guid("b3e9f0d6-1f2c-4d5e-8a0a-2c3d4e5f6b7a"),
                column: "State",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: new Guid("c7a8d1e5-4f3b-2c6e-9a0d-3e4f5a6b7c8d"),
                column: "State",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: new Guid("d2b4e7c9-3f6a-4e5b-8d0c-1a2b3c4d5e6f"),
                column: "State",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: new Guid("e8f1d3b5-6a7b-4c8e-9f0a-2b3c4d5e6a7d"),
                column: "State",
                value: 0);
        }
    }
}
