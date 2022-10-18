using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class h2002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkShift_Doctors_DoctorId",
                table: "WorkShift");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkShift_Shift_ShiftId",
                table: "WorkShift");

            migrationBuilder.DropTable(
                name: "MedicineBillInfo");

            migrationBuilder.DropTable(
                name: "MedicineBill");

            migrationBuilder.DropTable(
                name: "MedicineInfomation");

            migrationBuilder.DropTable(
                name: "MedicineType");

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

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Doctors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Doctors",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(255)");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Doctors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Department",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(255)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Doctors",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(255)");

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
                defaultValue: new DateTime(2022, 10, 17, 16, 55, 24, 66, DateTimeKind.Local).AddTicks(9901));

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

            migrationBuilder.CreateTable(
                name: "MedicineBills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 10, 17, 16, 55, 24, 66, DateTimeKind.Local).AddTicks(3393)),
                    PayStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineBills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicineTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicineInfomations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicineIDType = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImportDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 10, 17, 9, 55, 24, 66, DateTimeKind.Utc).AddTicks(2204)),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    UnitPrice = table.Column<int>(type: "int", nullable: false),
                    IsEmpty = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineInfomations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicineInfomations_MedicineTypes_MedicineIDType",
                        column: x => x.MedicineIDType,
                        principalTable: "MedicineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicineBillInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicineBillID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMedicineInfo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineBillInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicineBillInfos_MedicineBills_MedicineBillID",
                        column: x => x.MedicineBillID,
                        principalTable: "MedicineBills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicineBillInfos_MedicineInfomations_IdMedicineInfo",
                        column: x => x.IdMedicineInfo,
                        principalTable: "MedicineInfomations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkShifts_IdDoctor",
                table: "WorkShifts",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShifts_IdShift",
                table: "WorkShifts",
                column: "IdShift");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineBillInfos_IdMedicineInfo",
                table: "MedicineBillInfos",
                column: "IdMedicineInfo");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineBillInfos_MedicineBillID",
                table: "MedicineBillInfos",
                column: "MedicineBillID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineInfomations_MedicineIDType",
                table: "MedicineInfomations",
                column: "MedicineIDType");

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

            migrationBuilder.DropTable(
                name: "MedicineBillInfos");

            migrationBuilder.DropTable(
                name: "MedicineBills");

            migrationBuilder.DropTable(
                name: "MedicineInfomations");

            migrationBuilder.DropTable(
                name: "MedicineTypes");

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

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Doctors",
                type: "NVARCHAR(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Department",
                table: "Doctors",
                type: "NVARCHAR(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Doctors",
                type: "NVARCHAR(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

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

            migrationBuilder.CreateTable(
                name: "MedicineBill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 10, 6, 16, 23, 20, 918, DateTimeKind.Local).AddTicks(11)),
                    DoctorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PayStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineBill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicineType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicineInfomation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicineIDType = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImportDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 10, 6, 9, 23, 20, 917, DateTimeKind.Utc).AddTicks(8342)),
                    IsEmpty = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    UnitPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineInfomation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicineInfomation_MedicineType_MedicineIDType",
                        column: x => x.MedicineIDType,
                        principalTable: "MedicineType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicineBillInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicineBillID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicineInfomationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdMedicineInfo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineBillInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicineBillInfo_MedicineBill_MedicineBillID",
                        column: x => x.MedicineBillID,
                        principalTable: "MedicineBill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicineBillInfo_MedicineInfomation_MedicineInfomationId",
                        column: x => x.MedicineInfomationId,
                        principalTable: "MedicineInfomation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkShift_DoctorId",
                table: "WorkShift",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShift_ShiftId",
                table: "WorkShift",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineBillInfo_MedicineBillID",
                table: "MedicineBillInfo",
                column: "MedicineBillID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineBillInfo_MedicineInfomationId",
                table: "MedicineBillInfo",
                column: "MedicineInfomationId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineInfomation_MedicineIDType",
                table: "MedicineInfomation",
                column: "MedicineIDType");

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
