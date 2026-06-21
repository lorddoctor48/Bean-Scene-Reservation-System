using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Assessment_Bean_Scene_Registration_Application.Migrations
{
    /// <inheritdoc />
    public partial class changeTheRelationshipsReservationAndTableAsManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Table_TableNo",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_TableNo",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "TableNo",
                table: "Reservations");

            migrationBuilder.CreateTable(
                name: "ReservationTable",
                columns: table => new
                {
                    ReservationsReservationID = table.Column<int>(type: "int", nullable: false),
                    TableNo = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationTable", x => new { x.ReservationsReservationID, x.TableNo });
                    table.ForeignKey(
                        name: "FK_ReservationTable_Reservations_ReservationsReservationID",
                        column: x => x.ReservationsReservationID,
                        principalTable: "Reservations",
                        principalColumn: "ReservationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationTable_Table_TableNo",
                        column: x => x.TableNo,
                        principalTable: "Table",
                        principalColumn: "TableNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservationTable_TableNo",
                table: "ReservationTable",
                column: "TableNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationTable");

            migrationBuilder.AddColumn<string>(
                name: "TableNo",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TableNo",
                table: "Reservations",
                column: "TableNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Table_TableNo",
                table: "Reservations",
                column: "TableNo",
                principalTable: "Table",
                principalColumn: "TableNo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
