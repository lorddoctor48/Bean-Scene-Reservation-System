using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Assessment_Bean_Scene_Registration_Application.Migrations
{
    /// <inheritdoc />
    public partial class LinkedUsersToReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberID",
                table: "Reservations");

            migrationBuilder.AddColumn<DateOnly>(
                name: "ReservationDate",
                table: "Reservations",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Reservations",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationDate",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reservations");

            migrationBuilder.AddColumn<string>(
                name: "MemberID",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
