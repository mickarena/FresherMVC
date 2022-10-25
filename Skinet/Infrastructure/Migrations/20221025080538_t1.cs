using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class t1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "Shifts",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "Shifts",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Doctors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 25, 15, 5, 38, 640, DateTimeKind.Local).AddTicks(1645),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 19, 14, 54, 6, 625, DateTimeKind.Local).AddTicks(7005));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StartTime",
                table: "Shifts",
                type: "VARCHAR(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "EndTime",
                table: "Shifts",
                type: "VARCHAR(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Doctors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 19, 14, 54, 6, 625, DateTimeKind.Local).AddTicks(7005),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 25, 15, 5, 38, 640, DateTimeKind.Local).AddTicks(1645));
        }
    }
}
