using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaoInsur.Migrations
{
    /// <inheritdoc />
    public partial class AddedAlleytoAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Alley",
                table: "AppAddresses",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alley",
                table: "AppAddresses");
        }
    }
}
