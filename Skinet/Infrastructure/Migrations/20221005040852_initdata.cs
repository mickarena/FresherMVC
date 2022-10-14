using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class initdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Department = table.Column<string>(type: "NVARCHAR(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "MedicineBill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 10, 5, 11, 8, 52, 112, DateTimeKind.Local).AddTicks(8308)),
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
                name: "ProductBrands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdShift = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShiftName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicineInfomation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicineIDType = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImportDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 10, 5, 4, 8, 52, 112, DateTimeKind.Utc).AddTicks(7085)),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    UnitPrice = table.Column<int>(type: "int", nullable: false),
                    IsEmpty = table.Column<bool>(type: "bit", nullable: false)
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
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductBrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductBrands_ProductBrandId",
                        column: x => x.ProductBrandId,
                        principalTable: "ProductBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkShift",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDoctor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdShift = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShiftId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkShift", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkShift_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkShift_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shift",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicineBillInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicineBillID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMedicineInfo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    MedicineInfomationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductBrandId",
                table: "Products",
                column: "ProductBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShift_DoctorId",
                table: "WorkShift",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShift_ShiftId",
                table: "WorkShift",
                column: "ShiftId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HospitalBeds");

            migrationBuilder.DropTable(
                name: "MedicineBillInfo");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "WorkShift");

            migrationBuilder.DropTable(
                name: "MedicineBill");

            migrationBuilder.DropTable(
                name: "MedicineInfomation");

            migrationBuilder.DropTable(
                name: "ProductBrands");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropTable(
                name: "MedicineType");
        }
    }
}
