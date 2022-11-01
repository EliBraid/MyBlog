using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddTwoKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "BlogNews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "BlogNews",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "BlogNews");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "BlogNews");
        }
    }
}
