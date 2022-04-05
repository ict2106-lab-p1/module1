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
                name: "AccessoryTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Borrowable = table.Column<bool>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessoryTypes", x => x.Id);
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
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    OTP = table.Column<string>(type: "TEXT", nullable: false)
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
                    AuthenticationType = table.Column<string>(type: "TEXT", nullable: true),
                    OTP = table.Column<int>(type: "INTEGER", nullable: true),
                    SMSExpiry = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserFaculty = table.Column<string>(type: "TEXT", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "LabAccess",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LabId = table.Column<int>(type: "INTEGER", nullable: false),
                    InitiatorId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabAccess", x => new { x.UserId, x.LabId });
                    table.ForeignKey(
                        name: "FK_LabAccess_Users_InitiatorId",
                        column: x => x.InitiatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Labs",
                columns: table => new
                {
                    LabId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LabLocation = table.Column<string>(type: "TEXT", nullable: true),
                    LabStatus = table.Column<string>(type: "TEXT", nullable: true),
                    LabInCharge = table.Column<string>(type: "TEXT", nullable: true),
                    Occupied = table.Column<int>(type: "INTEGER", nullable: true),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: true),
                    Area = table.Column<int>(type: "INTEGER", nullable: true),
                    EnergyUsageBenchmark = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labs", x => x.LabId);
                    table.ForeignKey(
                        name: "FK_Labs_Users_LabInCharge",
                        column: x => x.LabInCharge,
                        principalTable: "Users",
                        principalColumn: "Id");
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

            migrationBuilder.CreateTable(
                name: "Accessories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "Date", nullable: false),
                    LabId = table.Column<int>(type: "INTEGER", nullable: false),
                    AccessoryTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LabUserId = table.Column<string>(type: "TEXT", nullable: true),
                    DueDate = table.Column<DateTime>(type: "Date", nullable: true),
                    ReviewStatus = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accessories_AccessoryTypes_AccessoryTypeId",
                        column: x => x.AccessoryTypeId,
                        principalTable: "AccessoryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accessories_Labs_LabId",
                        column: x => x.LabId,
                        principalTable: "Labs",
                        principalColumn: "LabId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    LabId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Booking_Labs_LabId",
                        column: x => x.LabId,
                        principalTable: "Labs",
                        principalColumn: "LabId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LastUpdated = table.Column<DateTime>(type: "Date", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    SerialNo = table.Column<string>(type: "TEXT", nullable: false),
                    LabId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Threshold = table.Column<double>(type: "REAL", nullable: true),
                    ReviewStatus = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_Labs_LabId",
                        column: x => x.LabId,
                        principalTable: "Labs",
                        principalColumn: "LabId",
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
                        name: "FK_SessionStats_Labs_LabId",
                        column: x => x.LabId,
                        principalTable: "Labs",
                        principalColumn: "LabId",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "LabId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnergyUsageLogs_Users_LoggedById",
                        column: x => x.LoggedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

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

            migrationBuilder.InsertData(
                table: "AccessoryTypes",
                columns: new[] { "Id", "Borrowable", "Description", "Type" },
                values: new object[] { 1, true, "Its purpose is to capture images and videos", "Camera" });

            migrationBuilder.InsertData(
                table: "AccessoryTypes",
                columns: new[] { "Id", "Borrowable", "Description", "Type" },
                values: new object[] { 2, true, "Its purpose is to detect obstacles", "Ultrasonic Sensor" });

            migrationBuilder.InsertData(
                table: "AccessoryTypes",
                columns: new[] { "Id", "Borrowable", "Description", "Type" },
                values: new object[] { 3, true, "Its purpose is to detect humidity in the environment", "Humidity Sensor" });

            migrationBuilder.InsertData(
                table: "AccessoryTypes",
                columns: new[] { "Id", "Borrowable", "Description", "Type" },
                values: new object[] { 4, true, "Its purpose is to detect water pressure", "Water pressure Sensor" });

            migrationBuilder.InsertData(
                table: "AccessoryTypes",
                columns: new[] { "Id", "Borrowable", "Description", "Type" },
                values: new object[] { 5, true, "It is used to switch on the lights in the lab", "IR Sensor" });

            migrationBuilder.InsertData(
                table: "AccessoryTypes",
                columns: new[] { "Id", "Borrowable", "Description", "Type" },
                values: new object[] { 6, true, "Its purpose is to detect proximity of an obstacle", "Proximity Sensor" });

            migrationBuilder.InsertData(
                table: "AccessoryTypes",
                columns: new[] { "Id", "Borrowable", "Description", "Type" },
                values: new object[] { 7, false, "Its purpose is to emit light", "LED Lights" });

            migrationBuilder.InsertData(
                table: "AccessoryTypes",
                columns: new[] { "Id", "Borrowable", "Description", "Type" },
                values: new object[] { 8, true, "Its purpose is to emit sound from the device", "Buzzer" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1", "", "User", "USER" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2", "", "Labtech", "LABTECH" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3", "", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "AuthenticationType", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SMSExpiry", "SecurityStamp", "TwoFactorEnabled", "UserFaculty", "UserName" },
                values: new object[] { "DefaultAdmin1", 0, "None", null, "nghanyi1997@gmail.com", true, "Sexy", "Sotong", true, null, "nghanyi1997@gmail.com", "nghanyi1997@gmail.com", null, "testtesttest", "To Be Changed", false, new DateTime(2022, 7, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), null, false, "SE", "nghanyi1997@gmail.com" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "AuthenticationType", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SMSExpiry", "SecurityStamp", "TwoFactorEnabled", "UserFaculty", "UserName" },
                values: new object[] { "DefaultAdmin2", 0, "None", null, "mailstohenry@gmail.com", true, "Ji Pyeong", "Han", true, null, "mailstohenry@gmail.com", "mailstohenry@gmail.com", null, "AQAAAAEAACcQAAAAEPF/ZkpS1YqBmjggtOKOcWkB7pkkWoGKjEpKtlAXD8m9s3ZFaBBdP0kRgtY+H/z77Q==", "To Be Changed", false, new DateTime(2022, 7, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), null, false, "SE", "mailstohenry@gmail.com" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "AuthenticationType", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SMSExpiry", "SecurityStamp", "TwoFactorEnabled", "UserFaculty", "UserName" },
                values: new object[] { "DefaultAdmin3", 0, "None", null, "shengyu98@hotmail.com", true, "Do San", "Nam", true, null, "shengyu98@hotmail.com", "shengyu98@hotmail.com", null, "testtesttest", "To Be Changed", false, new DateTime(2022, 7, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), null, false, "SE", "shengyu98@hotmail.com" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "AuthenticationType", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OTP", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SMSExpiry", "SecurityStamp", "TwoFactorEnabled", "UserFaculty", "UserName" },
                values: new object[] { "DefaultAdmin4", 0, "None", null, "test@gmail.com", false, "Test", "Test", true, null, null, "test@gmail.com", null, "testtesttest", "00000000", false, new DateTime(2022, 7, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), null, false, "ICT", "test@gmail.com" });

            migrationBuilder.InsertData(
                table: "LabAccess",
                columns: new[] { "LabId", "UserId", "InitiatorId" },
                values: new object[] { 1, "DefaultAdmin2", "DefaultAdmin1" });

            migrationBuilder.InsertData(
                table: "Labs",
                columns: new[] { "LabId", "Area", "Capacity", "EnergyUsageBenchmark", "LabInCharge", "LabLocation", "LabStatus", "Occupied" },
                values: new object[] { 1, null, 25, null, "DefaultAdmin1", "NYP-SR7A", "Available", 0 });

            migrationBuilder.InsertData(
                table: "Labs",
                columns: new[] { "LabId", "Area", "Capacity", "EnergyUsageBenchmark", "LabInCharge", "LabLocation", "LabStatus", "Occupied" },
                values: new object[] { 2, null, 30, null, "DefaultAdmin1", "NYP-SR7B", "Available", 0 });

            migrationBuilder.InsertData(
                table: "Labs",
                columns: new[] { "LabId", "Area", "Capacity", "EnergyUsageBenchmark", "LabInCharge", "LabLocation", "LabStatus", "Occupied" },
                values: new object[] { 3, null, 20, null, "DefaultAdmin1", "NYP-SR7C", "Available", 0 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "DefaultAdmin1" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2", "DefaultAdmin1" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3", "DefaultAdmin1" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "DefaultAdmin2" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2", "DefaultAdmin2" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3", "DefaultAdmin2" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "DefaultAdmin3" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2", "DefaultAdmin3" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3", "DefaultAdmin3" });

            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Name", "ReviewStatus", "Status" },
                values: new object[] { 1, 1, null, 1, null, new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sony A7 IV", "Pending", "Available" });

            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Name", "ReviewStatus", "Status" },
                values: new object[] { 2, 1, new DateTime(2022, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DefaultAdmin1", new DateTime(2021, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sony A8 IV", "Pending", "Borrowed" });

            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Name", "ReviewStatus", "Status" },
                values: new object[] { 3, 2, null, 2, null, new DateTime(2021, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "MA300D1-1", "Pending", "Available" });

            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Name", "ReviewStatus", "Status" },
                values: new object[] { 4, 2, null, 2, null, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "MA300D1-2", "Pending", "Available" });

            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Name", "ReviewStatus", "Status" },
                values: new object[] { 5, 3, new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "DefaultAdmin1", new DateTime(2021, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "DHT22", "Pending", "Borrowed" });

            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Name", "ReviewStatus", "Status" },
                values: new object[] { 6, 3, null, 3, null, new DateTime(2021, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "DHT23", "Pending", "Available" });

            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Name", "ReviewStatus", "Status" },
                values: new object[] { 7, 4, null, 1, null, new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LEFOO LFT2000W", "Pending", "Available" });

            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Name", "ReviewStatus", "Status" },
                values: new object[] { 8, 4, new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DefaultAdmin1", new DateTime(2021, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "LEFO1 LFT2000W", "Pending", "Borrowed" });

            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Name", "ReviewStatus", "Status" },
                values: new object[] { 9, 5, null, 2, null, new DateTime(2021, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM1802", "Pending", "Available" });

            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Name", "ReviewStatus", "Status" },
                values: new object[] { 10, 5, new DateTime(2022, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "DefaultAdmin1", new DateTime(2021, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM1803", "Pending", "Borrowed" });

            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Name", "ReviewStatus", "Status" },
                values: new object[] { 11, 6, null, 3, null, new DateTime(2021, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "HC-SR04", "Pending", "Available" });

            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Name", "ReviewStatus", "Status" },
                values: new object[] { 12, 6, null, 3, null, new DateTime(2021, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "HC-SR05", "Pending", "Available" });

            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Name", "ReviewStatus", "Status" },
                values: new object[] { 13, 7, new DateTime(2022, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DefaultAdmin1", new DateTime(2021, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "EDGELEC 4Pin LED Diodes", "Pending", "Borrowed" });

            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Name", "ReviewStatus", "Status" },
                values: new object[] { 14, 7, new DateTime(2022, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DefaultAdmin1", new DateTime(2021, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "EDGELEC 6Pin LED Diodes", "Pending", "Borrowed" });

            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Name", "ReviewStatus", "Status" },
                values: new object[] { 15, 8, null, 2, null, new DateTime(2021, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "TMB09A05", "Pending", "Available" });

            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "Id", "AccessoryTypeId", "DueDate", "LabId", "LabUserId", "LastUpdated", "Name", "ReviewStatus", "Status" },
                values: new object[] { 16, 8, null, 2, null, new DateTime(2021, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "TMB09A06", "Pending", "Available" });

            migrationBuilder.InsertData(
                table: "Booking",
                columns: new[] { "BookingId", "Description", "EndDateTime", "LabId", "StartDateTime", "UserId" },
                values: new object[] { 1, null, new DateTime(2022, 7, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2022, 7, 19, 10, 0, 0, 0, DateTimeKind.Unspecified), "DefaultAdmin3" });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "Description", "LabId", "LastUpdated", "Name", "ReviewStatus", "SerialNo", "Status", "Threshold", "Type" },
                values: new object[] { 1, "Its purpose is to detect situation in the laboratory", 1, new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Surveillance Camera", "Pending", "SC1001", "Available", null, "Surveillance Camera" });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "Description", "LabId", "LastUpdated", "Name", "ReviewStatus", "SerialNo", "Status", "Threshold", "Type" },
                values: new object[] { 2, "Its purpose is to detect temperature in the laboratory", 2, new DateTime(2020, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Temperature Sensor", "Approved", "R1001", "Available", null, "Temperature Sensor" });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "Description", "LabId", "LastUpdated", "Name", "ReviewStatus", "SerialNo", "Status", "Threshold", "Type" },
                values: new object[] { 3, "Its purpose is to detect humidity in the laboratory", 2, new DateTime(2020, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Humidity Sensor", "Approved", "S1001", "Available", null, "Humidity Sensor" });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "Description", "LabId", "LastUpdated", "Name", "ReviewStatus", "SerialNo", "Status", "Threshold", "Type" },
                values: new object[] { 4, "Its purpose is to detect light in the laboratory", 3, new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Light Sensor", "Rejected", "SL1001", "Available", null, "Light Sensor" });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "Description", "LabId", "LastUpdated", "Name", "ReviewStatus", "SerialNo", "Status", "Threshold", "Type" },
                values: new object[] { 5, "It is used to control brightness of the lights in the lab", 3, new DateTime(2019, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "VR Light Controls", "Pending", "VRL1001", "Unavailable", null, "VR Light Controls" });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "Description", "LabId", "LastUpdated", "Name", "ReviewStatus", "SerialNo", "Status", "Threshold", "Type" },
                values: new object[] { 6, "Its purpose is to detect situation in the laboratory", 1, new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Surveillance Camera", "Pending", "SC1001", "Available", null, "Surveillance Camera" });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "Description", "LabId", "LastUpdated", "Name", "ReviewStatus", "SerialNo", "Status", "Threshold", "Type" },
                values: new object[] { 7, "Its purpose is to detect temperature in the laboratory", 2, new DateTime(2020, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Temperature Sensor", "Approved", "R1001", "Available", null, "Temperature Sensor" });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "Description", "LabId", "LastUpdated", "Name", "ReviewStatus", "SerialNo", "Status", "Threshold", "Type" },
                values: new object[] { 8, "Its purpose is to detect humidity in the laboratory", 2, new DateTime(2020, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Humidity Sensor", "Approved", "S1001", "Available", null, "Humidity Sensor" });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "Description", "LabId", "LastUpdated", "Name", "ReviewStatus", "SerialNo", "Status", "Threshold", "Type" },
                values: new object[] { 9, "Its purpose is to detect light in the laboratory", 3, new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Light Sensor", "Rejected", "SL1001", "Available", null, "Light Sensor" });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "Description", "LabId", "LastUpdated", "Name", "ReviewStatus", "SerialNo", "Status", "Threshold", "Type" },
                values: new object[] { 10, "It is used to control brightness of the lights in the lab", 3, new DateTime(2019, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "VR Light Controls", "Pending", "VRL1001", "Unavailable", null, "VR Light Controls" });

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
                name: "IX_Accessories_AccessoryTypeId",
                table: "Accessories",
                column: "AccessoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessories_LabId",
                table: "Accessories",
                column: "LabId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserEmailLog_UsersId",
                table: "ApplicationUserEmailLog",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserSmsLog_UsersId",
                table: "ApplicationUserSmsLog",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_LabId",
                table: "Booking",
                column: "LabId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserId",
                table: "Booking",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CarbonFootprintEstimations_EnergyUsageLogId",
                table: "CarbonFootprintEstimations",
                column: "EnergyUsageLogId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_LabId",
                table: "Devices",
                column: "LabId");

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

            migrationBuilder.CreateIndex(
                name: "IX_LabAccess_InitiatorId",
                table: "LabAccess",
                column: "InitiatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Labs_LabInCharge",
                table: "Labs",
                column: "LabInCharge");

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
                name: "Accessories");

            migrationBuilder.DropTable(
                name: "ApplicationUserEmailLog");

            migrationBuilder.DropTable(
                name: "ApplicationUserSmsLog");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "CarbonFootprintEstimations");

            migrationBuilder.DropTable(
                name: "LabAccess");

            migrationBuilder.DropTable(
                name: "PowerGenerationMix");

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
                name: "AccessoryTypes");

            migrationBuilder.DropTable(
                name: "EmailLogs");

            migrationBuilder.DropTable(
                name: "SmsLogs");

            migrationBuilder.DropTable(
                name: "EnergyUsageLogs");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Labs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
