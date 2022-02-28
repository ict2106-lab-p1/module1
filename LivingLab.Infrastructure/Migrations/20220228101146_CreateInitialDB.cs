using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivingLab.Infrastructure.Migrations
{
    public partial class CreateInitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessoryType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Cost = table.Column<double>(type: "REAL", nullable: false),
                    Borrowable = table.Column<bool>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessoryType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Cost = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lab",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    PersonInCharge = table.Column<string>(type: "TEXT", nullable: false),
                    LabStatus = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lab", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accessory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    status = table.Column<string>(type: "TEXT", nullable: false),
                    ValidityDate = table.Column<DateTime>(type: "Date", nullable: false),
                    LabId = table.Column<int>(type: "INTEGER", nullable: false),
                    AccessoryTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accessory_AccessoryType_AccessoryTypeId",
                        column: x => x.AccessoryTypeId,
                        principalTable: "AccessoryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accessory_Lab_LabId",
                        column: x => x.LabId,
                        principalTable: "Lab",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ValidityDate = table.Column<DateTime>(type: "Date", nullable: false),
                    SerialNo = table.Column<string>(type: "TEXT", nullable: false),
                    LabId = table.Column<int>(type: "INTEGER", nullable: false),
                    DeviceTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Device_DeviceType_DeviceTypeId",
                        column: x => x.DeviceTypeId,
                        principalTable: "DeviceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Device_Lab_LabId",
                        column: x => x.LabId,
                        principalTable: "Lab",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NoOfHoursLogged = table.Column<int>(type: "INTEGER", nullable: true),
                    DeviceUsage = table.Column<string>(type: "TEXT", nullable: true),
                    LabId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Report_Lab_LabId",
                        column: x => x.LabId,
                        principalTable: "Lab",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogin_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AccessoryType",
                columns: new[] { "Id", "Borrowable", "Cost", "Description", "Name" },
                values: new object[] { 1, true, 499.0, "It''s purpose is to capture images and videos", "Camera" });

            migrationBuilder.InsertData(
                table: "AccessoryType",
                columns: new[] { "Id", "Borrowable", "Cost", "Description", "Name" },
                values: new object[] { 2, true, 1.0, "It''s purpose is to detect obstacles", "Ultrasonic Sensor" });

            migrationBuilder.InsertData(
                table: "AccessoryType",
                columns: new[] { "Id", "Borrowable", "Cost", "Description", "Name" },
                values: new object[] { 3, true, 3.0, "It''s purpose is to detect humidity in the environment", "Humidity Sensor" });

            migrationBuilder.InsertData(
                table: "AccessoryType",
                columns: new[] { "Id", "Borrowable", "Cost", "Description", "Name" },
                values: new object[] { 4, true, 7.0, "It''s purpose is to detect water pressure", "Water pressure Sensor" });

            migrationBuilder.InsertData(
                table: "AccessoryType",
                columns: new[] { "Id", "Borrowable", "Cost", "Description", "Name" },
                values: new object[] { 5, true, 2.0, "It is used to switch on the lights in the lab", "IR Sensor" });

            migrationBuilder.InsertData(
                table: "AccessoryType",
                columns: new[] { "Id", "Borrowable", "Cost", "Description", "Name" },
                values: new object[] { 6, true, 14.0, "It''s purpose is to detect proximity of an obstacle", "Proximity Sensor" });

            migrationBuilder.InsertData(
                table: "AccessoryType",
                columns: new[] { "Id", "Borrowable", "Cost", "Description", "Name" },
                values: new object[] { 7, false, 10.0, "It''s purpose is to emit light", "LED Lights" });

            migrationBuilder.InsertData(
                table: "AccessoryType",
                columns: new[] { "Id", "Borrowable", "Cost", "Description", "Name" },
                values: new object[] { 8, true, 1.0, "It''s purpose is to emit sound from the device", "Buzzer" });

            migrationBuilder.InsertData(
                table: "DeviceType",
                columns: new[] { "Id", "Cost", "Description", "Name" },
                values: new object[] { 1, 499.0, "It''s purpose is to detect situation in the laboratory", "Surveillance Camera" });

            migrationBuilder.InsertData(
                table: "DeviceType",
                columns: new[] { "Id", "Cost", "Description", "Name" },
                values: new object[] { 2, 130.0, "It''s purpose is to detect temperature in the laboratory", "Temperature Sensor" });

            migrationBuilder.InsertData(
                table: "DeviceType",
                columns: new[] { "Id", "Cost", "Description", "Name" },
                values: new object[] { 3, 130.0, "It''s purpose is to detect humidity in the laboratory", "Humidity Sensor" });

            migrationBuilder.InsertData(
                table: "DeviceType",
                columns: new[] { "Id", "Cost", "Description", "Name" },
                values: new object[] { 4, 320.0, "It''s purpose is to detect light in the laboratory", "Light Sensor" });

            migrationBuilder.InsertData(
                table: "DeviceType",
                columns: new[] { "Id", "Cost", "Description", "Name" },
                values: new object[] { 5, 323.0, "It is used to control brightness of the lights in the lab", "VR Light Controls" });

            migrationBuilder.InsertData(
                table: "Lab",
                columns: new[] { "Id", "LabStatus", "Location", "PersonInCharge" },
                values: new object[] { 1, "Available", "NYP-SR7C", "David" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "ValidityDate", "status" },
                values: new object[] { 1, 1, 1, new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "ValidityDate", "status" },
                values: new object[] { 2, 1, 1, new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Borrowed" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "ValidityDate", "status" },
                values: new object[] { 3, 2, 1, new DateTime(2024, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "ValidityDate", "status" },
                values: new object[] { 4, 2, 1, new DateTime(2024, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "ValidityDate", "status" },
                values: new object[] { 5, 3, 1, new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Borrowed" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "ValidityDate", "status" },
                values: new object[] { 6, 3, 1, new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "ValidityDate", "status" },
                values: new object[] { 7, 4, 1, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "ValidityDate", "status" },
                values: new object[] { 8, 4, 1, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Borrowed" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "ValidityDate", "status" },
                values: new object[] { 9, 5, 1, new DateTime(2024, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "ValidityDate", "status" },
                values: new object[] { 10, 5, 1, new DateTime(2024, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Borrowed" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "ValidityDate", "status" },
                values: new object[] { 11, 6, 1, new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "ValidityDate", "status" },
                values: new object[] { 12, 6, 1, new DateTime(2024, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "ValidityDate", "status" },
                values: new object[] { 13, 7, 1, new DateTime(2024, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Borrowed" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "ValidityDate", "status" },
                values: new object[] { 14, 7, 1, new DateTime(2024, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brrowed" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "ValidityDate", "status" },
                values: new object[] { 15, 8, 1, new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "ValidityDate", "status" },
                values: new object[] { 16, 8, 1, new DateTime(2024, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available" });

            migrationBuilder.InsertData(
                table: "Device",
                columns: new[] { "Id", "DeviceTypeId", "LabId", "SerialNo", "ValidityDate" },
                values: new object[] { 1, 1, 1, "SC1001", new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Device",
                columns: new[] { "Id", "DeviceTypeId", "LabId", "SerialNo", "ValidityDate" },
                values: new object[] { 2, 2, 1, "R1001", new DateTime(2020, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Device",
                columns: new[] { "Id", "DeviceTypeId", "LabId", "SerialNo", "ValidityDate" },
                values: new object[] { 3, 3, 1, "S1001", new DateTime(2020, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Device",
                columns: new[] { "Id", "DeviceTypeId", "LabId", "SerialNo", "ValidityDate" },
                values: new object[] { 4, 4, 1, "SL1001", new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Device",
                columns: new[] { "Id", "DeviceTypeId", "LabId", "SerialNo", "ValidityDate" },
                values: new object[] { 5, 5, 1, "VRL1001", new DateTime(2019, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Accessory_AccessoryTypeId",
                table: "Accessory",
                column: "AccessoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessory_LabId",
                table: "Accessory",
                column: "LabId");

            migrationBuilder.CreateIndex(
                name: "IX_Device_DeviceTypeId",
                table: "Device",
                column: "DeviceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Device_LabId",
                table: "Device",
                column: "LabId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_LabId",
                table: "Report",
                column: "LabId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Role",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId",
                table: "UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accessory");

            migrationBuilder.DropTable(
                name: "Device");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "Todos");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "AccessoryType");

            migrationBuilder.DropTable(
                name: "DeviceType");

            migrationBuilder.DropTable(
                name: "Lab");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
