using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class editdatetimenow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "WorkShifts",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 17, 16, 55, 24, 66, DateTimeKind.Local).AddTicks(9901));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ImportDate",
                table: "MedicineInfomations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 18, 8, 56, 43, 943, DateTimeKind.Utc).AddTicks(3068),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 17, 9, 55, 24, 66, DateTimeKind.Utc).AddTicks(2204));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "MedicineBills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 18, 15, 56, 43, 943, DateTimeKind.Local).AddTicks(3461),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 17, 16, 55, 24, 66, DateTimeKind.Local).AddTicks(3393));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "WorkShifts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 17, 16, 55, 24, 66, DateTimeKind.Local).AddTicks(9901),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ImportDate",
                table: "MedicineInfomations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 17, 9, 55, 24, 66, DateTimeKind.Utc).AddTicks(2204),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 18, 8, 56, 43, 943, DateTimeKind.Utc).AddTicks(3068));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "MedicineBills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 17, 16, 55, 24, 66, DateTimeKind.Local).AddTicks(3393),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 18, 15, 56, 43, 943, DateTimeKind.Local).AddTicks(3461));
        }
    }
}
