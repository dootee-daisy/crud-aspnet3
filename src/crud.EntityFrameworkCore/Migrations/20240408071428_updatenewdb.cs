using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace crud.Migrations
{
    public partial class updatenewdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "KhachHangs");

            migrationBuilder.AddColumn<DateTime>(
                name: "NgaySinh",
                table: "KhachHangs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NgaySinh",
                table: "KhachHangs");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "KhachHangs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
