using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ChristmasCalendar.Migrations
{
    public partial class PointsForDoor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PointsForCountry",
                table: "Door",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PointsForLocation",
                table: "Door",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PointsForCountry",
                table: "Door");

            migrationBuilder.DropColumn(
                name: "PointsForLocation",
                table: "Door");
        }
    }
}
