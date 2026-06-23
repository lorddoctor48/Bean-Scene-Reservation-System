using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Assessment_Bean_Scene_Registration_Application.Migrations
{
    /// <inheritdoc />
    public partial class ReaddedSittingStartTimeAndEndTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "SittingEndDate",
                table: "Sittings",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "SittingStartDate",
                table: "Sittings",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SittingEndDate",
                table: "Sittings");

            migrationBuilder.DropColumn(
                name: "SittingStartDate",
                table: "Sittings");
        }
    }
}
