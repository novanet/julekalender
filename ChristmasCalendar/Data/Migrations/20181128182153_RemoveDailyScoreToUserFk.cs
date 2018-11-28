using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ChristmasCalendar.Migrations
{
    public partial class RemoveDailyScoreToUserFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyScore_AspNetUsers_UserId",
                table: "DailyScore");

            migrationBuilder.DropIndex(
                name: "IX_DailyScore_UserId",
                table: "DailyScore");

            migrationBuilder.AddColumn<string>(
                name: "NameOfUser",
                table: "DailyScore",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameOfUser",
                table: "DailyScore");

            migrationBuilder.CreateIndex(
                name: "IX_DailyScore_UserId",
                table: "DailyScore",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyScore_AspNetUsers_UserId",
                table: "DailyScore",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
