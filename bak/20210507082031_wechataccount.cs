using Microsoft.EntityFrameworkCore.Migrations;

namespace LyyCMS.Migrations
{
    public partial class wechataccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppId",
                table: "WeChatAccount",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AppSecret",
                table: "WeChatAccount",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "WeChatAccount",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Originalid",
                table: "WeChatAccount",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Push",
                table: "WeChatAccount",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SortId",
                table: "WeChatAccount",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "WeChatAccount",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WechatCode",
                table: "WeChatAccount",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppId",
                table: "WeChatAccount");

            migrationBuilder.DropColumn(
                name: "AppSecret",
                table: "WeChatAccount");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "WeChatAccount");

            migrationBuilder.DropColumn(
                name: "Originalid",
                table: "WeChatAccount");

            migrationBuilder.DropColumn(
                name: "Push",
                table: "WeChatAccount");

            migrationBuilder.DropColumn(
                name: "SortId",
                table: "WeChatAccount");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "WeChatAccount");

            migrationBuilder.DropColumn(
                name: "WechatCode",
                table: "WeChatAccount");
        }
    }
}
