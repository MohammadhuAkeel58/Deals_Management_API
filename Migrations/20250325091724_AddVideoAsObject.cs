using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DealsManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddVideoAsObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Video",
                table: "Deals",
                type: "jsonb",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Video",
                table: "Deals");
        }
    }
}
