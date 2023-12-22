using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM_Api.Migrations
{
    /// <inheritdoc />
    public partial class ActModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Appointments_BuyerId",
                table: "Appointments");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_BuyerId",
                table: "Appointments",
                column: "BuyerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Appointments_BuyerId",
                table: "Appointments");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_BuyerId",
                table: "Appointments",
                column: "BuyerId");
        }
    }
}
