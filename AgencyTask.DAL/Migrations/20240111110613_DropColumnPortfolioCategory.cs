using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgencyTask.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DropColumnPortfolioCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Portfolios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
