using Microsoft.EntityFrameworkCore.Migrations;

namespace LyyCMS.Migrations
{
    public partial class fanscol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "groupid",
                table: "WxFansInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "qr_scene",
                table: "WxFansInfo",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "qr_scene_str",
                table: "WxFansInfo",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "remark",
                table: "WxFansInfo",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "subscribe",
                table: "WxFansInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "subscribe_scene",
                table: "WxFansInfo",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "groupid",
                table: "WxFansInfo");

            migrationBuilder.DropColumn(
                name: "qr_scene",
                table: "WxFansInfo");

            migrationBuilder.DropColumn(
                name: "qr_scene_str",
                table: "WxFansInfo");

            migrationBuilder.DropColumn(
                name: "remark",
                table: "WxFansInfo");

            migrationBuilder.DropColumn(
                name: "subscribe",
                table: "WxFansInfo");

            migrationBuilder.DropColumn(
                name: "subscribe_scene",
                table: "WxFansInfo");
        }
    }
}
