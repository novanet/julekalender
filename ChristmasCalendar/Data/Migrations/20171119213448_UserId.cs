using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ChristmasCalendar.Migrations
{
    public partial class UserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "FirstTimeOpeningDoor",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "DailyScore",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Answer",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "FirstTimeOpeningDoor",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "DailyScore",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Answer",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 450,
                oldNullable: true);
        }
    }
}
