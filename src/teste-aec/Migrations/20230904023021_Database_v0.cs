using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAec.Migrations
{
    /// <inheritdoc />
    public partial class Database_v0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherAirportResponse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Moisture = table.Column<int>(type: "int", nullable: true),
                    Visibility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ICAOCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AtmosphericPressure = table.Column<int>(type: "int", nullable: true),
                    Wind = table.Column<int>(type: "int", nullable: true),
                    WindDirection = table.Column<int>(type: "int", nullable: true),
                    ConditionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConditionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temperature = table.Column<int>(type: "int", nullable: true),
                    UpdateOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherAirportResponse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherCityResponse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherCityResponse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherCity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConditionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConditionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinTemperature = table.Column<float>(type: "real", nullable: true),
                    MaxTemperature = table.Column<float>(type: "real", nullable: true),
                    UvIndex = table.Column<float>(type: "real", nullable: true),
                    WeatherCityResponseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherCity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherCity_WeatherCityResponse_WeatherCityResponseId",
                        column: x => x.WeatherCityResponseId,
                        principalTable: "WeatherCityResponse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeatherCity_WeatherCityResponseId",
                table: "WeatherCity",
                column: "WeatherCityResponseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherAirportResponse");

            migrationBuilder.DropTable(
                name: "WeatherCity");

            migrationBuilder.DropTable(
                name: "WeatherCityResponse");
        }
    }
}
