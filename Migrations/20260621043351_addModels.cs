using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Assessment_Bean_Scene_Registration_Application.Migrations
{
    /// <inheritdoc />
    public partial class addModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReservationsSource",
                columns: table => new
                {
                    SourceTitleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceTitle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationsSource", x => x.SourceTitleId);
                });

            migrationBuilder.CreateTable(
                name: "SittingTypes",
                columns: table => new
                {
                    SittingTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SittingTitle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SittingTypes", x => x.SittingTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "TableAreas",
                columns: table => new
                {
                    Area = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableAreas", x => x.Area);
                });

            migrationBuilder.CreateTable(
                name: "Sittings",
                columns: table => new
                {
                    SittingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SittingTypeId = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    SittingStartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    SittingEndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    SittingStartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    SittingEndTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    SittingCapacity = table.Column<int>(type: "int", nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false),
                    ClosureDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ClosureReason = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sittings", x => x.SittingId);
                    table.ForeignKey(
                        name: "FK_Sittings_SittingTypes_SittingTypeId",
                        column: x => x.SittingTypeId,
                        principalTable: "SittingTypes",
                        principalColumn: "SittingTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Table",
                columns: table => new
                {
                    TableNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TableArea = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table", x => x.TableNo);
                    table.ForeignKey(
                        name: "FK_Table_TableAreas_TableArea",
                        column: x => x.TableArea,
                        principalTable: "TableAreas",
                        principalColumn: "Area",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SittingId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ReservationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ReservationStartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    ReservationEndTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    TableNo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NumberOfPeople = table.Column<int>(type: "int", nullable: false),
                    SourceTitleId = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    SpecialRequests = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationID);
                    table.ForeignKey(
                        name: "FK_Reservations_ReservationsSource_SourceTitleId",
                        column: x => x.SourceTitleId,
                        principalTable: "ReservationsSource",
                        principalColumn: "SourceTitleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Sittings_SittingId",
                        column: x => x.SittingId,
                        principalTable: "Sittings",
                        principalColumn: "SittingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Table_TableNo",
                        column: x => x.TableNo,
                        principalTable: "Table",
                        principalColumn: "TableNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_SittingId",
                table: "Reservations",
                column: "SittingId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_SourceTitleId",
                table: "Reservations",
                column: "SourceTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_StatusId",
                table: "Reservations",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TableNo",
                table: "Reservations",
                column: "TableNo");

            migrationBuilder.CreateIndex(
                name: "IX_Sittings_SittingTypeId",
                table: "Sittings",
                column: "SittingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SittingTypes_SittingTitle",
                table: "SittingTypes",
                column: "SittingTitle",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Table_TableArea",
                table: "Table",
                column: "TableArea");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "ReservationsSource");

            migrationBuilder.DropTable(
                name: "Sittings");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Table");

            migrationBuilder.DropTable(
                name: "SittingTypes");

            migrationBuilder.DropTable(
                name: "TableAreas");
        }
    }
}
