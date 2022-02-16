using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivingLab.Infrastructure.Migrations;

public partial class SeedDevices : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            table: "Devices",
            columns: new[] { "Id", "DeviceSerialNumber", "EnergyUsageThreshold", "Type" },
            values: new object[] { 1, "DEVICE-3390", 8591.0, "SmartSensor" });

        migrationBuilder.InsertData(
            table: "Devices",
            columns: new[] { "Id", "DeviceSerialNumber", "EnergyUsageThreshold", "Type" },
            values: new object[] { 2, "DEVICE-6049", 8154.0, "SmartSensor" });

        migrationBuilder.InsertData(
            table: "Devices",
            columns: new[] { "Id", "DeviceSerialNumber", "EnergyUsageThreshold", "Type" },
            values: new object[] { 3, "DEVICE-1598", 1184.0, "SmartSensor" });

        migrationBuilder.InsertData(
            table: "Devices",
            columns: new[] { "Id", "DeviceSerialNumber", "EnergyUsageThreshold", "Type" },
            values: new object[] { 4, "DEVICE-1232", 1173.0, "SmartSensor" });

        migrationBuilder.InsertData(
            table: "Devices",
            columns: new[] { "Id", "DeviceSerialNumber", "EnergyUsageThreshold", "Type" },
            values: new object[] { 5, "DEVICE-1123", 3451.0, "SmartSensor" });

        migrationBuilder.InsertData(
            table: "Devices",
            columns: new[] { "Id", "DeviceSerialNumber", "EnergyUsageThreshold", "Type" },
            values: new object[] { 6, "DEVICE-8987", 7794.0, "SmartSensor" });

        migrationBuilder.InsertData(
            table: "Devices",
            columns: new[] { "Id", "DeviceSerialNumber", "EnergyUsageThreshold", "Type" },
            values: new object[] { 7, "DEVICE-2435", 9568.0, "SmartSensor" });

        migrationBuilder.InsertData(
            table: "Devices",
            columns: new[] { "Id", "DeviceSerialNumber", "EnergyUsageThreshold", "Type" },
            values: new object[] { 8, "DEVICE-1234", 5908.0, "SmartSensor" });

        migrationBuilder.InsertData(
            table: "Devices",
            columns: new[] { "Id", "DeviceSerialNumber", "EnergyUsageThreshold", "Type" },
            values: new object[] { 9, "DEVICE-5423", 7794.0, "SmartSensor" });

        migrationBuilder.InsertData(
            table: "Devices",
            columns: new[] { "Id", "DeviceSerialNumber", "EnergyUsageThreshold", "Type" },
            values: new object[] { 10, "DEVICE-7452", 4386.0, "SmartSensor" });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "Devices",
            keyColumn: "Id",
            keyValue: 1);

        migrationBuilder.DeleteData(
            table: "Devices",
            keyColumn: "Id",
            keyValue: 2);

        migrationBuilder.DeleteData(
            table: "Devices",
            keyColumn: "Id",
            keyValue: 3);

        migrationBuilder.DeleteData(
            table: "Devices",
            keyColumn: "Id",
            keyValue: 4);

        migrationBuilder.DeleteData(
            table: "Devices",
            keyColumn: "Id",
            keyValue: 5);

        migrationBuilder.DeleteData(
            table: "Devices",
            keyColumn: "Id",
            keyValue: 6);

        migrationBuilder.DeleteData(
            table: "Devices",
            keyColumn: "Id",
            keyValue: 7);

        migrationBuilder.DeleteData(
            table: "Devices",
            keyColumn: "Id",
            keyValue: 8);

        migrationBuilder.DeleteData(
            table: "Devices",
            keyColumn: "Id",
            keyValue: 9);

        migrationBuilder.DeleteData(
            table: "Devices",
            keyColumn: "Id",
            keyValue: 10);
    }
}
