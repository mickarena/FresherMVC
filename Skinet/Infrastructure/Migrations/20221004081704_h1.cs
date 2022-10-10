using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class h1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicineBillInfo_MedicineBill_BillId",
                table: "MedicineBillInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicineBillInfo_MedicineInfomation_MedicineInfomationId",
                table: "MedicineBillInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicineInfomation_MedicineType_IdType",
                table: "MedicineInfomation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicineType",
                table: "MedicineType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicineInfomation",
                table: "MedicineInfomation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicineBillInfo",
                table: "MedicineBillInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicineBill",
                table: "MedicineBill");

            migrationBuilder.DropColumn(
                name: "PatientID",
                table: "MedicineBill");

            migrationBuilder.RenameTable(
                name: "MedicineType",
                newName: "MedicineTypes");

            migrationBuilder.RenameTable(
                name: "MedicineInfomation",
                newName: "MedicineInfomations");

            migrationBuilder.RenameTable(
                name: "MedicineBillInfo",
                newName: "MedicineBillInfos");

            migrationBuilder.RenameTable(
                name: "MedicineBill",
                newName: "MedicineBills");

            migrationBuilder.RenameColumn(
                name: "IdType",
                table: "MedicineInfomations",
                newName: "MedicineIDType");

            migrationBuilder.RenameIndex(
                name: "IX_MedicineInfomation_IdType",
                table: "MedicineInfomations",
                newName: "IX_MedicineInfomations_MedicineIDType");

            migrationBuilder.RenameColumn(
                name: "BillId",
                table: "MedicineBillInfos",
                newName: "MedicineBillID");

            migrationBuilder.RenameIndex(
                name: "IX_MedicineBillInfo_MedicineInfomationId",
                table: "MedicineBillInfos",
                newName: "IX_MedicineBillInfos_MedicineInfomationId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicineBillInfo_BillId",
                table: "MedicineBillInfos",
                newName: "IX_MedicineBillInfos_MedicineBillID");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MedicineTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "MedicineInfomations",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ImportDate",
                table: "MedicineInfomations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 4, 8, 17, 3, 896, DateTimeKind.Utc).AddTicks(4075),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MedicineInfomations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "MedicineBills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 4, 15, 17, 3, 896, DateTimeKind.Local).AddTicks(5540),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicineTypes",
                table: "MedicineTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicineInfomations",
                table: "MedicineInfomations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicineBillInfos",
                table: "MedicineBillInfos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicineBills",
                table: "MedicineBills",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineBillInfos_MedicineBills_MedicineBillID",
                table: "MedicineBillInfos",
                column: "MedicineBillID",
                principalTable: "MedicineBills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineBillInfos_MedicineInfomations_MedicineInfomationId",
                table: "MedicineBillInfos",
                column: "MedicineInfomationId",
                principalTable: "MedicineInfomations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineInfomations_MedicineTypes_MedicineIDType",
                table: "MedicineInfomations",
                column: "MedicineIDType",
                principalTable: "MedicineTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicineBillInfos_MedicineBills_MedicineBillID",
                table: "MedicineBillInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicineBillInfos_MedicineInfomations_MedicineInfomationId",
                table: "MedicineBillInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicineInfomations_MedicineTypes_MedicineIDType",
                table: "MedicineInfomations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicineTypes",
                table: "MedicineTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicineInfomations",
                table: "MedicineInfomations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicineBills",
                table: "MedicineBills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicineBillInfos",
                table: "MedicineBillInfos");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "MedicineInfomations");

            migrationBuilder.RenameTable(
                name: "MedicineTypes",
                newName: "MedicineType");

            migrationBuilder.RenameTable(
                name: "MedicineInfomations",
                newName: "MedicineInfomation");

            migrationBuilder.RenameTable(
                name: "MedicineBills",
                newName: "MedicineBill");

            migrationBuilder.RenameTable(
                name: "MedicineBillInfos",
                newName: "MedicineBillInfo");

            migrationBuilder.RenameColumn(
                name: "MedicineIDType",
                table: "MedicineInfomation",
                newName: "IdType");

            migrationBuilder.RenameIndex(
                name: "IX_MedicineInfomations_MedicineIDType",
                table: "MedicineInfomation",
                newName: "IX_MedicineInfomation_IdType");

            migrationBuilder.RenameColumn(
                name: "MedicineBillID",
                table: "MedicineBillInfo",
                newName: "BillId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicineBillInfos_MedicineInfomationId",
                table: "MedicineBillInfo",
                newName: "IX_MedicineBillInfo_MedicineInfomationId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicineBillInfos_MedicineBillID",
                table: "MedicineBillInfo",
                newName: "IX_MedicineBillInfo_BillId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MedicineType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "MedicineInfomation",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ImportDate",
                table: "MedicineInfomation",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 4, 8, 17, 3, 896, DateTimeKind.Utc).AddTicks(4075));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "MedicineBill",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 4, 15, 17, 3, 896, DateTimeKind.Local).AddTicks(5540));

            migrationBuilder.AddColumn<Guid>(
                name: "PatientID",
                table: "MedicineBill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicineType",
                table: "MedicineType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicineInfomation",
                table: "MedicineInfomation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicineBill",
                table: "MedicineBill",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicineBillInfo",
                table: "MedicineBillInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineBillInfo_MedicineBill_BillId",
                table: "MedicineBillInfo",
                column: "BillId",
                principalTable: "MedicineBill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineBillInfo_MedicineInfomation_MedicineInfomationId",
                table: "MedicineBillInfo",
                column: "MedicineInfomationId",
                principalTable: "MedicineInfomation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineInfomation_MedicineType_IdType",
                table: "MedicineInfomation",
                column: "IdType",
                principalTable: "MedicineType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
