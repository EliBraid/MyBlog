using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(12)", nullable: false),
                    Account = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(64)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeId",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(12)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogNews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Content = table.Column<string>(type: "Text", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ViewsCounts = table.Column<int>(type: "int", nullable: false),
                    LikedCounts = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    TypeInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogNews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogNews_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogNews_TypeId_TypeInfoId",
                        column: x => x.TypeInfoId,
                        principalTable: "TypeId",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogNews_AuthorId",
                table: "BlogNews",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogNews_TypeInfoId",
                table: "BlogNews",
                column: "TypeInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogNews");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "TypeId");
        }
    }
}
