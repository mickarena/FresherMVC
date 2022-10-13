using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdateDoctorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ImportDate",
                table: "MedicineInfomation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 6, 9, 23, 20, 917, DateTimeKind.Utc).AddTicks(8342),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 5, 4, 8, 52, 112, DateTimeKind.Utc).AddTicks(7085));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "MedicineBill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 6, 16, 23, 20, 918, DateTimeKind.Local).AddTicks(11),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 5, 11, 8, 52, 112, DateTimeKind.Local).AddTicks(8308));

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Doctors");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ImportDate",
                table: "MedicineInfomation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 5, 4, 8, 52, 112, DateTimeKind.Utc).AddTicks(7085),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 6, 9, 23, 20, 917, DateTimeKind.Utc).AddTicks(8342));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "MedicineBill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 5, 11, 8, 52, 112, DateTimeKind.Local).AddTicks(8308),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 6, 16, 23, 20, 918, DateTimeKind.Local).AddTicks(11));
        }
    }
}
