using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivingLab.Infrastructure.Migrations
{
    public partial class SeedLabs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 1,
                column: "EnergyUsageThreshold",
                value: 5619.0);

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 2,
                column: "EnergyUsageThreshold",
                value: 1392.0);

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 3,
                column: "EnergyUsageThreshold",
                value: 1514.0);

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 4,
                column: "EnergyUsageThreshold",
                value: 1490.0);

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 5,
                column: "EnergyUsageThreshold",
                value: 2082.0);

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 6,
                column: "EnergyUsageThreshold",
                value: 8112.0);

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 7,
                column: "EnergyUsageThreshold",
                value: 3956.0);

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 8,
                column: "EnergyUsageThreshold",
                value: 4877.0);

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 9,
                column: "EnergyUsageThreshold",
                value: 6933.0);

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 10,
                column: "EnergyUsageThreshold",
                value: 2700.0);

            migrationBuilder.InsertData(
                table: "Labs",
                columns: new[] { "Id", "Area" },
                values: new object[] { 1, 12.0 });

            migrationBuilder.InsertData(
                table: "Labs",
                columns: new[] { "Id", "Area" },
                values: new object[] { 2, 12.0 });

            migrationBuilder.InsertData(
                table: "Labs",
                columns: new[] { "Id", "Area" },
                values: new object[] { 3, 12.0 });

            migrationBuilder.InsertData(
                table: "Labs",
                columns: new[] { "Id", "Area" },
                values: new object[] { 4, 12.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Labs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Labs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Labs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Labs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 1,
                column: "EnergyUsageThreshold",
                value: 8591.0);

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 2,
                column: "EnergyUsageThreshold",
                value: 8154.0);

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 3,
                column: "EnergyUsageThreshold",
                value: 1184.0);

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 4,
                column: "EnergyUsageThreshold",
                value: 1173.0);

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 5,
                column: "EnergyUsageThreshold",
                value: 3451.0);

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 6,
                column: "EnergyUsageThreshold",
                value: 7794.0);

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 7,
                column: "EnergyUsageThreshold",
                value: 9568.0);

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 8,
                column: "EnergyUsageThreshold",
                value: 5908.0);

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 9,
                column: "EnergyUsageThreshold",
                value: 7794.0);

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 10,
                column: "EnergyUsageThreshold",
                value: 4386.0);
        }
    }
}
