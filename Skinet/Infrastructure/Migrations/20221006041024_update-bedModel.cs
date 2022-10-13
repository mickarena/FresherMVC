using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class updatebedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ImportDate",
                table: "MedicineInfomation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 6, 4, 10, 24, 467, DateTimeKind.Utc).AddTicks(5469),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 5, 7, 45, 49, 640, DateTimeKind.Utc).AddTicks(5508));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "MedicineBill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 6, 11, 10, 24, 467, DateTimeKind.Local).AddTicks(8277),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 5, 14, 45, 49, 640, DateTimeKind.Local).AddTicks(9310));

            migrationBuilder.AlterColumn<string>(
                name: "IDRoom",
                table: "HospitalBeds",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "IDPatient",
                table: "HospitalBeds",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ImportDate",
                table: "MedicineInfomation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 5, 7, 45, 49, 640, DateTimeKind.Utc).AddTicks(5508),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 6, 4, 10, 24, 467, DateTimeKind.Utc).AddTicks(5469));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "MedicineBill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 5, 14, 45, 49, 640, DateTimeKind.Local).AddTicks(9310),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 6, 11, 10, 24, 467, DateTimeKind.Local).AddTicks(8277));

            migrationBuilder.AlterColumn<int>(
                name: "IDRoom",
                table: "HospitalBeds",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "IDPatient",
                table: "HospitalBeds",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
