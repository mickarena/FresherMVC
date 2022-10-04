using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class h10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameIndex(
                name: "IX_MedicineInfomations_MedicineIDType",
                table: "MedicineInfomation",
                newName: "IX_MedicineInfomation_MedicineIDType");

            migrationBuilder.RenameIndex(
                name: "IX_MedicineBillInfos_MedicineInfomationId",
                table: "MedicineBillInfo",
                newName: "IX_MedicineBillInfo_MedicineInfomationId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicineBillInfos_MedicineBillID",
                table: "MedicineBillInfo",
                newName: "IX_MedicineBillInfo_MedicineBillID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ImportDate",
                table: "MedicineInfomation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 4, 11, 4, 12, 466, DateTimeKind.Utc).AddTicks(8313),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 4, 8, 17, 3, 896, DateTimeKind.Utc).AddTicks(4075));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "MedicineBill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 4, 18, 4, 12, 466, DateTimeKind.Local).AddTicks(9336),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 4, 15, 17, 3, 896, DateTimeKind.Local).AddTicks(5540));

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

            migrationBuilder.CreateTable(
                name: "HospitalBeds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDRoom = table.Column<int>(type: "int", nullable: false),
                    IDPatient = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalBeds", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineBillInfo_MedicineBill_MedicineBillID",
                table: "MedicineBillInfo",
                column: "MedicineBillID",
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
                name: "FK_MedicineInfomation_MedicineType_MedicineIDType",
                table: "MedicineInfomation",
                column: "MedicineIDType",
                principalTable: "MedicineType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicineBillInfo_MedicineBill_MedicineBillID",
                table: "MedicineBillInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicineBillInfo_MedicineInfomation_MedicineInfomationId",
                table: "MedicineBillInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicineInfomation_MedicineType_MedicineIDType",
                table: "MedicineInfomation");

            migrationBuilder.DropTable(
                name: "HospitalBeds");

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

            migrationBuilder.RenameIndex(
                name: "IX_MedicineInfomation_MedicineIDType",
                table: "MedicineInfomations",
                newName: "IX_MedicineInfomations_MedicineIDType");

            migrationBuilder.RenameIndex(
                name: "IX_MedicineBillInfo_MedicineInfomationId",
                table: "MedicineBillInfos",
                newName: "IX_MedicineBillInfos_MedicineInfomationId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicineBillInfo_MedicineBillID",
                table: "MedicineBillInfos",
                newName: "IX_MedicineBillInfos_MedicineBillID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ImportDate",
                table: "MedicineInfomations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 4, 8, 17, 3, 896, DateTimeKind.Utc).AddTicks(4075),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 4, 11, 4, 12, 466, DateTimeKind.Utc).AddTicks(8313));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "MedicineBills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 4, 15, 17, 3, 896, DateTimeKind.Local).AddTicks(5540),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 4, 18, 4, 12, 466, DateTimeKind.Local).AddTicks(9336));

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
    }
}
