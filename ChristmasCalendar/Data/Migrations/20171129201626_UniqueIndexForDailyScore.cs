using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ChristmasCalendar.Migrations
{
    public partial class UniqueIndexForDailyScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "UQ_UniqueUserEntryPerDoor",
                table: "DailyScore",
                columns: new[] { "DoorId", "UserId" },
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ_UniqueUserEntryPerDoor",
                table: "DailyScore");
        }
    }
}
