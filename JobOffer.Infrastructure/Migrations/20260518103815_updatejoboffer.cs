using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobOffer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatejoboffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TenantId",
                table: "JobOffereds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "JobOffereds");
        }
    }
}
