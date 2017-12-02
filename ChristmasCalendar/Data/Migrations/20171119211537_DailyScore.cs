using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ChristmasCalendar.Migrations
{
    public partial class DailyScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "FirstTimeOpeningDoor",
                newName: "DoorId");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Answer",
                newName: "DoorId");

            migrationBuilder.CreateTable(
                name: "DailyScore",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bonus = table.Column<int>(nullable: false),
                    DoorId = table.Column<int>(nullable: false),
                    Points = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyScore", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyScore");

            migrationBuilder.RenameColumn(
                name: "DoorId",
                table: "FirstTimeOpeningDoor",
                newName: "ImageId");

            migrationBuilder.RenameColumn(
                name: "DoorId",
                table: "Answer",
                newName: "ImageId");
        }
    }
}
