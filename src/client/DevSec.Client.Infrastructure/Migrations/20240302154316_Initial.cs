using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevSec.Client.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceConfigurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsCompressEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsNotificationsEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsMotionRecognitionEnabled = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceConfigurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoundSources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Moniker = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoundSources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoConfigurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Height = table.Column<int>(type: "INTEGER", nullable: false),
                    Width = table.Column<int>(type: "INTEGER", nullable: false),
                    FramesPerSecond = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoConfigurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoSources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Moniker = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoSources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceSounds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SourceId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceSounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceSounds_SoundSources_SourceId",
                        column: x => x.SourceId,
                        principalTable: "SoundSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceVideos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConfigurationId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceVideos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceVideos_VideoConfigurations_ConfigurationId",
                        column: x => x.ConfigurationId,
                        principalTable: "VideoConfigurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceVideos_VideoSources_SourceId",
                        column: x => x.SourceId,
                        principalTable: "VideoSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IsEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    Color_Red = table.Column<byte>(type: "INTEGER", nullable: true),
                    Color_Green = table.Column<byte>(type: "INTEGER", nullable: true),
                    Color_Blue = table.Column<byte>(type: "INTEGER", nullable: true),
                    Color_Opacity = table.Column<float>(type: "REAL", nullable: true),
                    Location_Latitude = table.Column<float>(type: "REAL", nullable: true),
                    Location_Longtitude = table.Column<float>(type: "REAL", nullable: true),
                    SoundId = table.Column<Guid>(type: "TEXT", nullable: true),
                    VideoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConfigurationId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_DeviceConfigurations_ConfigurationId",
                        column: x => x.ConfigurationId,
                        principalTable: "DeviceConfigurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Devices_DeviceSounds_SoundId",
                        column: x => x.SoundId,
                        principalTable: "DeviceSounds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Devices_DeviceVideos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "DeviceVideos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceDeviceGroup",
                columns: table => new
                {
                    DevicesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    GroupId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceDeviceGroup", x => new { x.DevicesId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_DeviceDeviceGroup_Devices_DevicesId",
                        column: x => x.DevicesId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceDeviceGroup_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceDeviceGroup_GroupId",
                table: "DeviceDeviceGroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_ConfigurationId",
                table: "Devices",
                column: "ConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_SoundId",
                table: "Devices",
                column: "SoundId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_VideoId",
                table: "Devices",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceSounds_SourceId",
                table: "DeviceSounds",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceVideos_ConfigurationId",
                table: "DeviceVideos",
                column: "ConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceVideos_SourceId",
                table: "DeviceVideos",
                column: "SourceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceDeviceGroup");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "DeviceConfigurations");

            migrationBuilder.DropTable(
                name: "DeviceSounds");

            migrationBuilder.DropTable(
                name: "DeviceVideos");

            migrationBuilder.DropTable(
                name: "SoundSources");

            migrationBuilder.DropTable(
                name: "VideoConfigurations");

            migrationBuilder.DropTable(
                name: "VideoSources");
        }
    }
}
