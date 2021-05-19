using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LyyCMS.Migrations
{
    public partial class wxfanscol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "WxFansInfo",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "WxFansInfo",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "headimgurl",
                table: "WxFansInfo",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "language",
                table: "WxFansInfo",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "nickname",
                table: "WxFansInfo",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "openid",
                table: "WxFansInfo",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "province",
                table: "WxFansInfo",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "sex",
                table: "WxFansInfo",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "subscribe_time",
                table: "WxFansInfo",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "unionid",
                table: "WxFansInfo",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "weChaId",
                table: "WxFansInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "count",
                table: "WxFansGroup",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "groupId",
                table: "WxFansGroup",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "WxFansGroup",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "weChaId",
                table: "WxFansGroup",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WxFansInfo_weChaId",
                table: "WxFansInfo",
                column: "weChaId");

            migrationBuilder.CreateIndex(
                name: "IX_WxFansGroup_weChaId",
                table: "WxFansGroup",
                column: "weChaId");

            migrationBuilder.AddForeignKey(
                name: "FK_WxFansGroup_WeChatAccount_weChaId",
                table: "WxFansGroup",
                column: "weChaId",
                principalTable: "WeChatAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WxFansInfo_WeChatAccount_weChaId",
                table: "WxFansInfo",
                column: "weChaId",
                principalTable: "WeChatAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WxFansGroup_WeChatAccount_weChaId",
                table: "WxFansGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_WxFansInfo_WeChatAccount_weChaId",
                table: "WxFansInfo");

            migrationBuilder.DropIndex(
                name: "IX_WxFansInfo_weChaId",
                table: "WxFansInfo");

            migrationBuilder.DropIndex(
                name: "IX_WxFansGroup_weChaId",
                table: "WxFansGroup");

            migrationBuilder.DropColumn(
                name: "city",
                table: "WxFansInfo");

            migrationBuilder.DropColumn(
                name: "country",
                table: "WxFansInfo");

            migrationBuilder.DropColumn(
                name: "headimgurl",
                table: "WxFansInfo");

            migrationBuilder.DropColumn(
                name: "language",
                table: "WxFansInfo");

            migrationBuilder.DropColumn(
                name: "nickname",
                table: "WxFansInfo");

            migrationBuilder.DropColumn(
                name: "openid",
                table: "WxFansInfo");

            migrationBuilder.DropColumn(
                name: "province",
                table: "WxFansInfo");

            migrationBuilder.DropColumn(
                name: "sex",
                table: "WxFansInfo");

            migrationBuilder.DropColumn(
                name: "subscribe_time",
                table: "WxFansInfo");

            migrationBuilder.DropColumn(
                name: "unionid",
                table: "WxFansInfo");

            migrationBuilder.DropColumn(
                name: "weChaId",
                table: "WxFansInfo");

            migrationBuilder.DropColumn(
                name: "count",
                table: "WxFansGroup");

            migrationBuilder.DropColumn(
                name: "groupId",
                table: "WxFansGroup");

            migrationBuilder.DropColumn(
                name: "name",
                table: "WxFansGroup");

            migrationBuilder.DropColumn(
                name: "weChaId",
                table: "WxFansGroup");
        }
    }
}
