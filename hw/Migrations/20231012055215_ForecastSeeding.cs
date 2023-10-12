using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace hw.Migrations
{
    /// <inheritdoc />
    public partial class ForecastSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Forecasts",
                columns: new[] { "Id", "Latitude", "Longitude", "Temperature", "TemperatureUnit" },
                values: new object[,]
                {
                    { 1, 47.674f, -122.1215f, 58.2f, 2 },
                    { 2, 34.0522f, -118.2437f, 71.6f, 2 },
                    { 3, 40.7143f, -74.006f, 61.3f, 2 },
                    { 4, 33.4484f, -112.074f, 90.1f, 2 },
                    { 5, 38.9415f, -76.965f, 58.6f, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Forecasts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Forecasts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Forecasts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Forecasts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Forecasts",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
