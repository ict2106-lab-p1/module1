using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivingLab.Infrastructure.Migrations
{
    public partial class CreateInitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Accessory
            migrationBuilder.CreateTable(
                name: "Accessory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccessoryTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "Date", nullable: false),
                    LabId = table.Column<int>(type: "INTEGER", nullable: false),
                    // LabUserId to be linked to account table
                    // Used to indicate the user that borrowed the accessory
                    LabUserId = table.Column<int>(type: "INTEGER", nullable: true),
                    DueDate = table.Column<DateTime>(type: "Date", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accessory_Lab_LabId",
                        column: x => x.LabId,
                        principalTable: "Lab",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accessory_AccessoryType_AccessoryTypeId",
                        column: x => x.AccessoryTypeId,
                        principalTable: "AccessoryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    // LabUserId to be linked to account table
                    // table.ForeignKey(
                    //     name: "FK_Accessory_Account_LabUserId",
                    //     column: x => x.LabUserId,
                    //     principalTable: "Account",
                    //     principalColumn: "Id",
                    //     onDelete: ReferentialAction.Cascade);
                });
            
            // AccessoryType
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

            // Device
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
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
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
            
            // Lab
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
            
            // Logging
            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NoOfHoursLogged = table.Column<int>(type: "INTEGER", nullable: true),
                    DataUploaded = table.Column<string>(type: "TEXT", nullable: true),
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
            
            
            // Misc tables for login
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

            migrationBuilder.InsertData(
                table: "AccessoryType",
                columns: new[] { "Id", "Borrowable", "Type", "Description", "Name" },
                values: new object[] { 1, true, "Camera", "It''s purpose is to capture images and videos", "Sony A7 IV" });

            migrationBuilder.InsertData(
                table: "AccessoryType",
                columns: new[] { "Id", "Borrowable", "Type", "Description", "Name" },
                values: new object[] { 2, true, "Ultrasonic Sensor", "It''s purpose is to detect obstacles", "MA300D1-1" });

            migrationBuilder.InsertData(
                table: "AccessoryType",
                columns: new[] { "Id", "Borrowable", "Type", "Description", "Name" },
                values: new object[] { 3, true, "Humidity Sensor", "It''s purpose is to detect humidity in the environment", "DHT22" });

            migrationBuilder.InsertData(
                table: "AccessoryType",
                columns: new[] { "Id", "Borrowable", "Type", "Description", "Name" },
                values: new object[] { 4, true, "Water pressure Sensor", "It''s purpose is to detect water pressure", "LEFOO LFT2000W" });

            migrationBuilder.InsertData(
                table: "AccessoryType",
                columns: new[] { "Id", "Borrowable", "Type", "Description", "Name" },
                values: new object[] { 5, true, "IR Sensor", "It is used to switch on the lights in the lab", "RM1802" });

            migrationBuilder.InsertData(
                table: "AccessoryType",
                columns: new[] { "Id", "Borrowable", "Type", "Description", "Name" },
                values: new object[] { 6, true, "Proximity Sensor", "It''s purpose is to detect proximity of an obstacle", "HC-SR04" });

            migrationBuilder.InsertData(
                table: "AccessoryType",
                columns: new[] { "Id", "Borrowable", "Type", "Description", "Name" },
                values: new object[] { 7, false, "LED Lights", "It''s purpose is to emit light", "EDGELEC 4Pin LED Diodes" });

            migrationBuilder.InsertData(
                table: "AccessoryType",
                columns: new[] { "Id", "Borrowable", "Type", "Description", "Name" },
                values: new object[] { 8, true, "Buzzer", "It''s purpose is to emit sound from the device", "TMB09A05" });

            migrationBuilder.InsertData(
                table: "Lab",
                columns: new[] { "Id", "LabStatus", "Location", "PersonInCharge" },
                values: new object[] { 1, "Available", "NYP-SR7C", "David" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "LastUpdated", "Status" },
                values: new object[] { 1, 1, 1, new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "LastUpdated", "Status", "LabUserId", "DueDate" },
                values: new object[] { 2, 1, 1, new DateTime(2021, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Borrowed", 1, new DateTime(2022, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "LastUpdated", "Status"},
                values: new object[] { 3, 2, 1, new DateTime(2021, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "LastUpdated", "Status"},
                values: new object[] { 4, 2, 1, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "LastUpdated", "Status", "LabUserId", "DueDate" },
                values: new object[] { 5, 3, 1, new DateTime(2021, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Borrowed", 2, new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "LastUpdated", "Status" },
                values: new object[] { 6, 3, 1, new DateTime(2021, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "LastUpdated", "Status" },
                values: new object[] { 7, 4, 1, new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "LastUpdated", "Status", "LabUserId", "DueDate" },
                values: new object[] { 8, 4, 1, new DateTime(2021, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Borrowed", 3, new DateTime(2022, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)});

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "LastUpdated", "Status" },
                values: new object[] { 9, 5, 1, new DateTime(2021, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "LastUpdated", "Status", "LabUserId", "DueDate" },
                values: new object[] { 10, 5, 1, new DateTime(2021, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Borrowed", 4, new DateTime(2022, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "LastUpdated", "Status" },
                values: new object[] { 11, 6, 1, new DateTime(2021, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "LastUpdated", "Status" },
                values: new object[] { 12, 6, 1, new DateTime(2021, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "LastUpdated", "Status", "LabUserId", "DueDate" },
                values: new object[] { 13, 7, 1, new DateTime(2021, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Borrowed", 5, new DateTime(2022, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "LastUpdated", "Status", "LabUserId", "DueDate" },
                values: new object[] { 14, 7, 1, new DateTime(2021, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Borrowed", 6, new DateTime(2022, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "LastUpdated", "Status" },
                values: new object[] { 15, 8, 1, new DateTime(2021, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available" });

            migrationBuilder.InsertData(
                table: "Accessory",
                columns: new[] { "Id", "AccessoryTypeId", "LabId", "LastUpdated", "Status" },
                values: new object[] { 16, 8, 1, new DateTime(2021, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available" });
 
            migrationBuilder.InsertData(
                table: "Device",
                columns: new[] { "Id", "DeviceTypeId", "LabId", "SerialNo", "LastUpdated", "Status", "Name", "Description" },
                values: new object[] { 1, 1, 1, "SC1001", new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "Surveillance Camera", "Its purpose is to detect situation in the laboratory" });

            migrationBuilder.InsertData(
                table: "Device",
                columns: new[] { "Id", "DeviceTypeId", "LabId", "SerialNo", "LastUpdated", "Status", "Name", "Description" },
                values: new object[] { 2, 2, 1, "R1001", new DateTime(2020, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "Temperature Sensor", "Its purpose is to detect temperature in the laboratory" });

            migrationBuilder.InsertData(
                table: "Device",
                columns: new[] { "Id", "DeviceTypeId", "LabId", "SerialNo", "LastUpdated", "Status", "Name", "Description" },
                values: new object[] { 3, 3, 1, "S1001", new DateTime(2020, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available", "Humidity Sensor", "Its purpose is to detect humidity in the laboratory" });

            migrationBuilder.InsertData(
                table: "Device",
                columns: new[] { "Id", "DeviceTypeId", "LabId", "SerialNo", "LastUpdated", "Status", "Name", "Description" },
                values: new object[] { 4, 4, 1, "SL1001", new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Available" ,"Light Sensor", "Its purpose is to detect light in the laboratory" });

            migrationBuilder.InsertData(
                table: "Device",
                columns: new[] { "Id", "DeviceTypeId", "LabId", "SerialNo", "LastUpdated", "Status", "Name", "Description" },
                values: new object[] { 5, 5, 1, "VRL1001", new DateTime(2019, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Unavailable", "VR Light Controls", "It is used to control brightness of the lights in the lab"});

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
