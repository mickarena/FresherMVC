using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class SkinetV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkShift_Doctors_DoctorId",
                table: "WorkShift");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkShift_Shift_ShiftId",
                table: "WorkShift");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkShift",
                table: "WorkShift");

            migrationBuilder.DropIndex(
                name: "IX_WorkShift_DoctorId",
                table: "WorkShift");

            migrationBuilder.DropIndex(
                name: "IX_WorkShift_ShiftId",
                table: "WorkShift");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shift",
                table: "Shift");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "WorkShift");

            migrationBuilder.DropColumn(
                name: "ShiftId",
                table: "WorkShift");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "WorkShift");

            migrationBuilder.DropColumn(
                name: "IdShift",
                table: "Shift");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Shift");

            migrationBuilder.RenameTable(
                name: "WorkShift",
                newName: "WorkShifts");

            migrationBuilder.RenameTable(
                name: "Shift",
                newName: "Shifts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ImportDate",
                table: "MedicineInfomation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 9, 7, 36, 57, 477, DateTimeKind.Utc).AddTicks(5),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 5, 4, 8, 52, 112, DateTimeKind.Utc).AddTicks(7085));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "MedicineBill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 9, 14, 36, 57, 477, DateTimeKind.Local).AddTicks(1072),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 5, 11, 8, 52, 112, DateTimeKind.Local).AddTicks(8308));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "WorkShifts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "WorkShifts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 9, 14, 36, 57, 477, DateTimeKind.Local).AddTicks(6159));

            migrationBuilder.AlterColumn<string>(
                name: "ShiftName",
                table: "Shifts",
                type: "NVARCHAR(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EndTime",
                table: "Shifts",
                type: "VARCHAR(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StartTime",
                table: "Shifts",
                type: "VARCHAR(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkShifts",
                table: "WorkShifts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shifts",
                table: "Shifts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShifts_IdDoctor",
                table: "WorkShifts",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShifts_IdShift",
                table: "WorkShifts",
                column: "IdShift");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkShifts_Doctors_IdDoctor",
                table: "WorkShifts",
                column: "IdDoctor",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkShifts_Shifts_IdShift",
                table: "WorkShifts",
                column: "IdShift",
                principalTable: "Shifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkShifts_Doctors_IdDoctor",
                table: "WorkShifts");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkShifts_Shifts_IdShift",
                table: "WorkShifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkShifts",
                table: "WorkShifts");

            migrationBuilder.DropIndex(
                name: "IX_WorkShifts_IdDoctor",
                table: "WorkShifts");

            migrationBuilder.DropIndex(
                name: "IX_WorkShifts_IdShift",
                table: "WorkShifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shifts",
                table: "Shifts");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "WorkShifts");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Shifts");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Shifts");

            migrationBuilder.RenameTable(
                name: "WorkShifts",
                newName: "WorkShift");

            migrationBuilder.RenameTable(
                name: "Shifts",
                newName: "Shift");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ImportDate",
                table: "MedicineInfomation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 5, 4, 8, 52, 112, DateTimeKind.Utc).AddTicks(7085),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 9, 7, 36, 57, 477, DateTimeKind.Utc).AddTicks(5));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "MedicineBill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 5, 11, 8, 52, 112, DateTimeKind.Local).AddTicks(8308),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 9, 14, 36, 57, 477, DateTimeKind.Local).AddTicks(1072));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "WorkShift",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "DoctorId",
                table: "WorkShift",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ShiftId",
                table: "WorkShift",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "WorkShift",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShiftName",
                table: "Shift",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<Guid>(
                name: "IdShift",
                table: "Shift",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "Shift",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkShift",
                table: "WorkShift",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shift",
                table: "Shift",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShift_DoctorId",
                table: "WorkShift",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShift_ShiftId",
                table: "WorkShift",
                column: "ShiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkShift_Doctors_DoctorId",
                table: "WorkShift",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkShift_Shift_ShiftId",
                table: "WorkShift",
                column: "ShiftId",
                principalTable: "Shift",
                principalColumn: "Id");
        }
    }
}
