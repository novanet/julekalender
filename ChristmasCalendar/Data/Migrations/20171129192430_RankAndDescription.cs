using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ChristmasCalendar.Migrations
{
    public partial class RankAndDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Door",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "DailyScore",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RankMovement",
                table: "DailyScore",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Door");

            migrationBuilder.DropColumn(
                name: "Rank",
                table: "DailyScore");

            migrationBuilder.DropColumn(
                name: "RankMovement",
                table: "DailyScore");
        }
    }
}
