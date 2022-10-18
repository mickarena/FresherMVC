using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class updatnursedepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Doctor_IdDoctor",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Shifts_IdShift",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_HospitalBeds_Departments_DepartmentId",
                table: "HospitalBeds");

            migrationBuilder.DropIndex(
                name: "IX_HospitalBeds_DepartmentId",
                table: "HospitalBeds");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Doctor_TempId",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "HospitalBeds");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "HospitalBeds");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "HospitalBeds");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "HospitalBeds");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "HospitalBeds");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "HospitalBeds");

            migrationBuilder.DropColumn(
                name: "JoinDate",
                table: "HospitalBeds");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "HospitalBeds");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "HospitalBeds");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "HospitalBeds");

            migrationBuilder.DropColumn(
                name: "IdDoctor",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "IdShift",
                table: "Departments");

            migrationBuilder.RenameTable(
                name: "Doctor",
                newName: "Doctors");

            migrationBuilder.RenameColumn(
                name: "TempId",
                table: "Doctors",
                newName: "Gender");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ImportDate",
                table: "MedicineInfomations",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 18, 8, 57, 1, 455, DateTimeKind.Utc).AddTicks(4227));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "MedicineBills",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 18, 15, 57, 1, 455, DateTimeKind.Local).AddTicks(4685));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Doctors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Doctors",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Doctors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 18, 17, 41, 20, 812, DateTimeKind.Local).AddTicks(1544));

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Doctors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Doctors",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Doctors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Nurse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nurse_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nurse_DepartmentId",
                table: "Nurse",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductBrands_ProductBrandId",
                table: "Products",
                column: "ProductBrandId",
                principalTable: "ProductBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId",
                table: "Products",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Products_ProductBrands_ProductBrandId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkShifts_Doctors_IdDoctor",
                table: "WorkShifts");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkShifts_Shifts_IdShift",
                table: "WorkShifts");

            migrationBuilder.DropTable(
                name: "Nurse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Doctors");

            migrationBuilder.RenameTable(
                name: "Doctors",
                newName: "Doctor");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Doctor",
                newName: "TempId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ImportDate",
                table: "MedicineInfomations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 18, 8, 57, 1, 455, DateTimeKind.Utc).AddTicks(4227),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "MedicineBills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 18, 15, 57, 1, 455, DateTimeKind.Local).AddTicks(4685),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "HospitalBeds",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "HospitalBeds",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "HospitalBeds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "HospitalBeds",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "HospitalBeds",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "HospitalBeds",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "JoinDate",
                table: "HospitalBeds",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "HospitalBeds",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "HospitalBeds",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "HospitalBeds",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdDoctor",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdShift",
                table: "Departments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Doctor_TempId",
                table: "Doctor",
                column: "TempId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalBeds_DepartmentId",
                table: "HospitalBeds",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Doctor_IdDoctor",
                table: "Departments",
                column: "IdDoctor",
                principalTable: "Doctor",
                principalColumn: "TempId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Shifts_IdShift",
                table: "Departments",
                column: "IdShift",
                principalTable: "Shifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalBeds_Departments_DepartmentId",
                table: "HospitalBeds",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }
    }
}
