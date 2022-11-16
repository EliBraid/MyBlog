using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyBlog.Repository.Migrations
{
    /// <inheritdoc />
    public partial class initseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BlogNews",
                columns: new[] { "Id", "AuthorId", "Content", "CreateTime", "LikedCounts", "Title", "TypeInfoId", "ViewsCounts" },
                values: new object[,]
                {
                    { 1, 1, "小说你写的", new DateTime(2022, 11, 16, 17, 16, 49, 326, DateTimeKind.Local).AddTicks(7569), 0, "是你的", 1, 0 },
                    { 2, 1, "不死小说", new DateTime(2022, 11, 16, 17, 16, 49, 326, DateTimeKind.Local).AddTicks(7584), 0, "而现在", 1, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlogNews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BlogNews",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
