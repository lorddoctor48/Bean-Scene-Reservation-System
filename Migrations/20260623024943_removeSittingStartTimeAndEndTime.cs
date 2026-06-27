using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Assessment_Bean_Scene_Registration_Application.Migrations
{
    /// <inheritdoc />
    public partial class removeSittingStartTimeAndEndTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SittingEndDate",
                table: "Sittings");

            migrationBuilder.RenameColumn(
                name: "SittingStartDate",
                table: "Sittings",
                newName: "SittingDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SittingDate",
                table: "Sittings",
                newName: "SittingStartDate");

            migrationBuilder.AddColumn<DateOnly>(
                name: "SittingEndDate",
                table: "Sittings",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}
