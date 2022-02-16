
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivingLab.Infrastructure.Migrations;

public partial class CreateMod2DB : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.RenameColumn(
            name: "ID",
            table: "Todos",
            newName: "Id");

        migrationBuilder.AlterColumn<string>(
            name: "LastName",
            table: "Users",
            type: "TEXT",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "TEXT");

        migrationBuilder.AlterColumn<string>(
            name: "FirstName",
            table: "Users",
            type: "TEXT",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "TEXT");

        migrationBuilder.CreateTable(
            name: "Devices",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                DeviceSerialNumber = table.Column<string>(type: "TEXT", nullable: false),
                Type = table.Column<string>(type: "TEXT", nullable: false),
                EnergyUsageThreshold = table.Column<double>(type: "REAL", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Devices", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Labs",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Area = table.Column<double>(type: "REAL", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Labs", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "EnergyUsageLogs",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                EnergyUsage = table.Column<double>(type: "REAL", nullable: false),
                Interval = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                LoggedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                LoggedById = table.Column<string>(type: "TEXT", nullable: true),
                LabId = table.Column<int>(type: "INTEGER", nullable: false),
                DeviceId = table.Column<int>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_EnergyUsageLogs", x => x.Id);
                table.ForeignKey(
                    name: "FK_EnergyUsageLogs_Devices_DeviceId",
                    column: x => x.DeviceId,
                    principalTable: "Devices",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_EnergyUsageLogs_Labs_LabId",
                    column: x => x.LabId,
                    principalTable: "Labs",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_EnergyUsageLogs_Users_LoggedById",
                    column: x => x.LoggedById,
                    principalTable: "Users",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateIndex(
            name: "IX_EnergyUsageLogs_DeviceId",
            table: "EnergyUsageLogs",
            column: "DeviceId");

        migrationBuilder.CreateIndex(
            name: "IX_EnergyUsageLogs_LabId",
            table: "EnergyUsageLogs",
            column: "LabId");

        migrationBuilder.CreateIndex(
            name: "IX_EnergyUsageLogs_LoggedById",
            table: "EnergyUsageLogs",
            column: "LoggedById");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "EnergyUsageLogs");

        migrationBuilder.DropTable(
            name: "Devices");

        migrationBuilder.DropTable(
            name: "Labs");

        migrationBuilder.RenameColumn(
            name: "Id",
            table: "Todos",
            newName: "ID");

        migrationBuilder.AlterColumn<string>(
            name: "LastName",
            table: "Users",
            type: "TEXT",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "TEXT",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "FirstName",
            table: "Users",
            type: "TEXT",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "TEXT",
            oldNullable: true);
    }
}
