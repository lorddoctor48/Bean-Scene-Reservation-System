using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project_Assessment_Bean_Scene_Registration_Application.Migrations
{
    /// <inheritdoc />
    public partial class addSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ReservationsSource",
                columns: new[] { "SourceTitleId", "SourceTitle" },
                values: new object[,]
                {
                    { 1, "Phone" },
                    { 2, "Email" },
                    { 3, "Online" },
                    { 4, "In-person" }
                });

            migrationBuilder.InsertData(
                table: "SittingTypes",
                columns: new[] { "SittingTypeId", "SittingTitle" },
                values: new object[,]
                {
                    { 1, "Breakfast" },
                    { 2, "Lunch" },
                    { 3, "Dinner" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "StatusId", "StatusTitle" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Confirmed" },
                    { 3, "Cancelled" },
                    { 4, "Seated" },
                    { 5, "Completed" }
                });

            migrationBuilder.InsertData(
                table: "TableAreas",
                columns: new[] { "TableAreaId", "Area" },
                values: new object[,]
                {
                    { 1, "Main" },
                    { 2, "Outside" },
                    { 3, "Balcony" }
                });

            migrationBuilder.InsertData(
                table: "Table",
                columns: new[] { "TableNo", "TableAreaId" },
                values: new object[,]
                {
                    { "B1", 3 },
                    { "B10", 3 },
                    { "B2", 3 },
                    { "B3", 3 },
                    { "B4", 3 },
                    { "B5", 3 },
                    { "B6", 3 },
                    { "B7", 3 },
                    { "B8", 3 },
                    { "B9", 3 },
                    { "M1", 1 },
                    { "M10", 1 },
                    { "M2", 1 },
                    { "M3", 1 },
                    { "M4", 1 },
                    { "M5", 1 },
                    { "M6", 1 },
                    { "M7", 1 },
                    { "M8", 1 },
                    { "M9", 1 },
                    { "O1", 2 },
                    { "O10", 2 },
                    { "O2", 2 },
                    { "O3", 2 },
                    { "O4", 2 },
                    { "O5", 2 },
                    { "O6", 2 },
                    { "O7", 2 },
                    { "O8", 2 },
                    { "O9", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ReservationsSource",
                keyColumn: "SourceTitleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ReservationsSource",
                keyColumn: "SourceTitleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ReservationsSource",
                keyColumn: "SourceTitleId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ReservationsSource",
                keyColumn: "SourceTitleId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SittingTypes",
                keyColumn: "SittingTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SittingTypes",
                keyColumn: "SittingTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SittingTypes",
                keyColumn: "SittingTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "StatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "StatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "StatusId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "StatusId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "StatusId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableNo",
                keyValue: "B1");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableNo",
                keyValue: "B10");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableNo",
                keyValue: "B2");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableNo",
                keyValue: "B3");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableNo",
                keyValue: "B4");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableNo",
                keyValue: "B5");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableNo",
                keyValue: "B6");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableNo",
                keyValue: "B7");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableNo",
                keyValue: "B8");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableNo",
                keyValue: "B9");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableNo",
                keyValue: "M1");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableNo",
                keyValue: "M10");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableNo",
                keyValue: "M2");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableNo",
                keyValue: "M3");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableNo",
                keyValue: "M4");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableNo",
                keyValue: "M5");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableNo",
                keyValue: "M6");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableNo",
                keyValue: "M7");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableNo",
                keyValue: "M8");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableNo",
                keyValue: "M9");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableNo",
                keyValue: "O1");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableNo",
                keyValue: "O10");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableNo",
                keyValue: "O2");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableNo",
                keyValue: "O3");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableNo",
                keyValue: "O4");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableNo",
                keyValue: "O5");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableNo",
                keyValue: "O6");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableNo",
                keyValue: "O7");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableNo",
                keyValue: "O8");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "TableNo",
                keyValue: "O9");

            migrationBuilder.DeleteData(
                table: "TableAreas",
                keyColumn: "TableAreaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TableAreas",
                keyColumn: "TableAreaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TableAreas",
                keyColumn: "TableAreaId",
                keyValue: 3);
        }
    }
}
