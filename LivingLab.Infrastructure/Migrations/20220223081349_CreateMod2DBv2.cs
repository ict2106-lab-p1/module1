using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivingLab.Infrastructure.Migrations
{
    public partial class CreateMod2DBv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarbonFootprintEstimations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CO2Emission = table.Column<double>(type: "REAL", nullable: false),
                    EnergyUsageLogId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarbonFootprintEstimations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarbonFootprintEstimations_EnergyUsageLogs_EnergyUsageLogId",
                        column: x => x.EnergyUsageLogId,
                        principalTable: "EnergyUsageLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Message = table.Column<string>(type: "TEXT", nullable: false),
                    Subject = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    LoggedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnergyUsagePredictions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EstimatedUsage = table.Column<double>(type: "REAL", nullable: false),
                    LoggedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LabId = table.Column<int>(type: "INTEGER", nullable: false),
                    DeviceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyUsagePredictions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnergyUsagePredictions_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnergyUsagePredictions_Labs_LabId",
                        column: x => x.LabId,
                        principalTable: "Labs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PowerGenerationMix",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FuelName = table.Column<string>(type: "TEXT", nullable: false),
                    PercentContribution = table.Column<double>(type: "REAL", nullable: false),
                    CO2PerUnitEnergy = table.Column<double>(type: "REAL", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerGenerationMix", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmsLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Message = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    LoggedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserEmailLog",
                columns: table => new
                {
                    NotificationEmailsId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserEmailLog", x => new { x.NotificationEmailsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserEmailLog_EmailLogs_NotificationEmailsId",
                        column: x => x.NotificationEmailsId,
                        principalTable: "EmailLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserEmailLog_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserSmsLog",
                columns: table => new
                {
                    NotificationSmsesId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserSmsLog", x => new { x.NotificationSmsesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserSmsLog_SmsLogs_NotificationSmsesId",
                        column: x => x.NotificationSmsesId,
                        principalTable: "SmsLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserSmsLog_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserEmailLog_UsersId",
                table: "ApplicationUserEmailLog",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserSmsLog_UsersId",
                table: "ApplicationUserSmsLog",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_CarbonFootprintEstimations_EnergyUsageLogId",
                table: "CarbonFootprintEstimations",
                column: "EnergyUsageLogId");

            migrationBuilder.CreateIndex(
                name: "IX_EnergyUsagePredictions_DeviceId",
                table: "EnergyUsagePredictions",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_EnergyUsagePredictions_LabId",
                table: "EnergyUsagePredictions",
                column: "LabId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserEmailLog");

            migrationBuilder.DropTable(
                name: "ApplicationUserSmsLog");

            migrationBuilder.DropTable(
                name: "CarbonFootprintEstimations");

            migrationBuilder.DropTable(
                name: "EnergyUsagePredictions");

            migrationBuilder.DropTable(
                name: "PowerGenerationMix");

            migrationBuilder.DropTable(
                name: "EmailLogs");

            migrationBuilder.DropTable(
                name: "SmsLogs");
        }
    }
}
