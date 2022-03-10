﻿using System;
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
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Borrowable = table.Column<bool>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessoryType", x => x.Id);
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
                    Title = table.Column<string>(type: "TEXT", nullable: true),
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
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "Date", nullable: false),
                    LabId = table.Column<int>(type: "INTEGER", nullable: false),
                    AccessoryTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    LabUserId = table.Column<int>(type: "INTEGER", nullable: true),
                    DueDate = table.Column<DateTime>(type: "Date", nullable: true)
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
                    LastUpdated = table.Column<DateTime>(type: "Date", nullable: false),
                    SerialNo = table.Column<string>(type: "TEXT", nullable: false),
                    LabId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Threshold = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Device_Lab_LabId",
                        column: x => x.LabId,
                        principalTable: "Lab",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LoginTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LogoutTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataUploaded = table.Column<double>(type: "REAL", nullable: true),
                    LabId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionStats_Lab_LabId",
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
                columns: new[] { "Id", "Borrowable", "Description", "Name", "Type" },
                values: new object[] { 1, true, "Its purpose is to capture images and videos", "Sony A7 IV", "Camera" });

            migrationBuilder.InsertData(
                table: "AccessoryType",
                columns: new[] { "Id", "Borrowable", "Description", "Name", "Type" },
                values: new object[] { 2, true, "Its purpose is to detect obstacles", "MA300D1-1", "Ultrasonic Sensor" });

            migrationBuilder.InsertData(
                table: "AccessoryType",
                columns: new[] { "Id", "Borrowable", "Description", "Name", "Type" },
                values: new object[] { 3, true, "Its purpose is to detect humidity in the environment", "DHT22", "Humidity Sensor" });

            migrationBuilder.InsertData(
                table: "AccessoryType",
                columns: new[] { "Id", "Borrowable", "Description", "Name", "Type" },
                values: new object[] { 4, true, "Its purpose is to detect water pressure", "LEFOO LFT2000W", "Water pressure Sensor" });

            migrationBuilder.InsertData(
                table: "AccessoryType",
                columns: new[] { "Id", "Borrowable", "Description", "Name", "Type" },
                values: new object[] { 5, true, "It is used to switch on the lights in the lab", "RM1802", "IR Sensor" });

            migrationBuilder.InsertData(
                table: "AccessoryType",
                columns: new[] { "Id", "Borrowable", "Description", "Name", "Type" },
                values: new object[] { 6, true, "Its purpose is to detect proximity of an obstacle", "HC-SR04", "Proximity Sensor" });

            migrationBuilder.InsertData(
                table: "AccessoryType",
                columns: new[] { "Id", "Borrowable", "Description", "Name", "Type" },
                values: new object[] { 7, false, "Its purpose is to emit light", "EDGELEC 4Pin LED Diodes", "LED Lights" });

            migrationBuilder.InsertData(
                table: "AccessoryType",
                columns: new[] { "Id", "Borrowable", "Description", "Name", "Type" },
                values: new object[] { 8, true, "Its purpose is to emit sound from the device", "TMB09A05", "Buzzer" });

            migrationBuilder.InsertData(
                table: "Lab",
                columns: new[] { "Id", "LabStatus", "Location", "PersonInCharge" },
                values: new object[] { 1, "Available", "NYP-SR7C", "David" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Status" },
                values: new object[] { 1, 1, null, 1, null, new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Status" },
                values: new object[] { 2, 1, new DateTime(2022, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2021, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Borrowed" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Status" },
                values: new object[] { 3, 2, null, 1, null, new DateTime(2021, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Status" },
                values: new object[] { 4, 2, null, 1, null, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Status" },
                values: new object[] { 5, 3, new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, new DateTime(2021, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Borrowed" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Status" },
                values: new object[] { 6, 3, null, 1, null, new DateTime(2021, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Status" },
                values: new object[] { 7, 4, null, 1, null, new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Status" },
                values: new object[] { 8, 4, new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, new DateTime(2021, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Borrowed" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Status" },
                values: new object[] { 9, 5, null, 1, null, new DateTime(2021, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Status" },
                values: new object[] { 10, 5, new DateTime(2022, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, new DateTime(2021, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Borrowed" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Status" },
                values: new object[] { 11, 6, null, 1, null, new DateTime(2021, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Status" },
                values: new object[] { 12, 6, null, 1, null, new DateTime(2021, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Status" },
                values: new object[] { 13, 7, new DateTime(2022, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, new DateTime(2021, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Borrowed" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Status" },
                values: new object[] { 14, 7, new DateTime(2022, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 6, new DateTime(2021, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Borrowed" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Status" },
                values: new object[] { 15, 8, null, 1, null, new DateTime(2021, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Status" },
                values: new object[] { 16, 8, null, 1, null, new DateTime(2021, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available" });

            migrationBuilder.InsertData(
                table: "Device",
                columns: new[] { "Id", "Description", "LabId", "LastUpdated", "SerialNo", "Status", "Threshold", "Type" },
                values: new object[] { 1, "Its purpose is to detect situation in the laboratory", 1, new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC1001", "Available", null, "Surveillance Camera" });

            migrationBuilder.InsertData(
                table: "Device",
                columns: new[] { "Id", "Description", "LabId", "LastUpdated", "SerialNo", "Status", "Threshold", "Type" },
                values: new object[] { 2, "Its purpose is to detect temperature in the laboratory", 1, new DateTime(2020, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "R1001", "Available", null, "Temperature Sensor" });

            migrationBuilder.InsertData(
                table: "Device",
                columns: new[] { "Id", "Description", "LabId", "LastUpdated", "SerialNo", "Status", "Threshold", "Type" },
                values: new object[] { 3, "Its purpose is to detect humidity in the laboratory", 1, new DateTime(2020, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "S1001", "Available", null, "Humidity Sensor" });

            migrationBuilder.InsertData(
                table: "Device",
                columns: new[] { "Id", "Description", "LabId", "LastUpdated", "SerialNo", "Status", "Threshold", "Type" },
                values: new object[] { 4, "Its purpose is to detect light in the laboratory", 1, new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SL1001", "Available", null, "Light Sensor" });

            migrationBuilder.InsertData(
                table: "Device",
                columns: new[] { "Id", "Description", "LabId", "LastUpdated", "SerialNo", "Status", "Threshold", "Type" },
                values: new object[] { 5, "It is used to control brightness of the lights in the lab", 1, new DateTime(2019, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "VRL1001", "Unavailable", null, "VR Light Controls" });

            migrationBuilder.InsertData(
                table: "SessionStats",
                columns: new[] { "Id", "DataUploaded", "Date", "LabId", "LoginTime", "LogoutTime" },
                values: new object[] { 1, 58.0, new DateTime(2021, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 7, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 3, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "SessionStats",
                columns: new[] { "Id", "DataUploaded", "Date", "LabId", "LoginTime", "LogoutTime" },
                values: new object[] { 2, 64.0, new DateTime(2021, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 7, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 4, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "SessionStats",
                columns: new[] { "Id", "DataUploaded", "Date", "LabId", "LoginTime", "LogoutTime" },
                values: new object[] { 3, 128.0, new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 7, 5, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 5, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Accessory_AccessoryTypeId",
                table: "Accessory",
                column: "AccessoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessory_LabId",
                table: "Accessory",
                column: "LabId");

            migrationBuilder.CreateIndex(
                name: "IX_Device_LabId",
                table: "Device",
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
                name: "IX_SessionStats_LabId",
                table: "SessionStats",
                column: "LabId");

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
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "SessionStats");

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
                name: "Lab");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
