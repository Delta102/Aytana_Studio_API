using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM_Api.Migrations
{
    /// <inheritdoc />
    public partial class ActWithIdKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Workers",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Workers",
                newName: "name");
        }
    }
}
