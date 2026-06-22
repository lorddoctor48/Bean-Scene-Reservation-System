using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Assessment_Bean_Scene_Registration_Application.Migrations
{
    /// <inheritdoc />
    public partial class addUniqueDataAnnotationToAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Table_TableNo",
                table: "Table",
                column: "TableNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Status_StatusTitle",
                table: "Status",
                column: "StatusTitle",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReservationsSource_SourceTitle",
                table: "ReservationsSource",
                column: "SourceTitle",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Table_TableNo",
                table: "Table");

            migrationBuilder.DropIndex(
                name: "IX_Status_StatusTitle",
                table: "Status");

            migrationBuilder.DropIndex(
                name: "IX_ReservationsSource_SourceTitle",
                table: "ReservationsSource");
        }
    }
}
