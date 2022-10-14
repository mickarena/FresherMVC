using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class addbed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ImportDate",
                table: "MedicineInfomation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 5, 7, 45, 49, 640, DateTimeKind.Utc).AddTicks(5508),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 5, 4, 8, 52, 112, DateTimeKind.Utc).AddTicks(7085));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "MedicineBill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 5, 14, 45, 49, 640, DateTimeKind.Local).AddTicks(9310),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 5, 11, 8, 52, 112, DateTimeKind.Local).AddTicks(8308));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ImportDate",
                table: "MedicineInfomation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 5, 4, 8, 52, 112, DateTimeKind.Utc).AddTicks(7085),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 5, 7, 45, 49, 640, DateTimeKind.Utc).AddTicks(5508));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "MedicineBill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 5, 11, 8, 52, 112, DateTimeKind.Local).AddTicks(8308),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 5, 14, 45, 49, 640, DateTimeKind.Local).AddTicks(9310));
        }
    }
}
