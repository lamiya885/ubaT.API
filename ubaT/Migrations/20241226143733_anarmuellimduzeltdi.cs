using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ubaT.Migrations
{
    /// <inheritdoc />
    public partial class anarmuellimduzeltdi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WordText",
                table: "BannedWords");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WordText",
                table: "BannedWords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
