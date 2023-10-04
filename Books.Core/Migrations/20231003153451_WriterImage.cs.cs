using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Books.Core.Migrations
{
    /// <inheritdoc />
    public partial class WriterImagecs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WriterImage",
                table: "Writers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WriterImage",
                table: "Writers");
        }
    }
}
