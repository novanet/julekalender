using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ChristmasCalendar.Migrations
{
    public partial class ApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyScore_AspNetUsers_UserId",
                table: "DailyScore");

            migrationBuilder.DropIndex(
                name: "IX_DailyScore_UserId",
                table: "DailyScore");
        }
    }
}
