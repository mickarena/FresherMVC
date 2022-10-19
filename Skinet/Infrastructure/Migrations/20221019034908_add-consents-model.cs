using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class addconsentsmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Doctors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 19, 10, 49, 8, 147, DateTimeKind.Local).AddTicks(1167),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Agree = table.Column<bool>(type: "bit", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InviteEduQuest = table.Column<bool>(type: "bit", nullable: false),
                    Award = table.Column<bool>(type: "bit", nullable: false),
                    ApplicantAwardStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcceptOfferLetter = table.Column<bool>(type: "bit", nullable: true),
                    AcceptOfferLetterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CourierOfferLetter = table.Column<bool>(type: "bit", nullable: true),
                    IsRegistered = table.Column<bool>(type: "bit", nullable: false),
                    IsTransferredToESMS = table.Column<bool>(type: "bit", nullable: false),
                    StatusId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "processFlowConfigurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationYear = table.Column<int>(type: "int", nullable: false),
                    SPMYear = table.Column<int>(type: "int", nullable: false),
                    AgeFrom = table.Column<int>(type: "int", nullable: false),
                    AgeTo = table.Column<int>(type: "int", nullable: false),
                    TotalOfAs = table.Column<int>(type: "int", nullable: false),
                    TotalSPMSubject = table.Column<int>(type: "int", nullable: false),
                    DefaultBulletinId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_processFlowConfigurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProcessFlowConfigurationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consents_processFlowConfigurations_ProcessFlowConfigurationId",
                        column: x => x.ProcessFlowConfigurationId,
                        principalTable: "processFlowConfigurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "applicationConsents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Answer = table.Column<bool>(type: "bit", nullable: false),
                    StatusId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicationConsents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_applicationConsents_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_applicationConsents_Consents_ConsentId",
                        column: x => x.ConsentId,
                        principalTable: "Consents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_applicationConsents_ApplicationId",
                table: "applicationConsents",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_applicationConsents_ConsentId",
                table: "applicationConsents",
                column: "ConsentId");

            migrationBuilder.CreateIndex(
                name: "IX_Consents_ProcessFlowConfigurationId",
                table: "Consents",
                column: "ProcessFlowConfigurationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "applicationConsents");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Consents");

            migrationBuilder.DropTable(
                name: "processFlowConfigurations");

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Doctors",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 19, 10, 49, 8, 147, DateTimeKind.Local).AddTicks(1167));
        }
    }
}
