
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobOffer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AttachmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CV",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "CV_AttachmentId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Attachment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uploaded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CV_AttachmentId",
                table: "AspNetUsers",
                column: "CV_AttachmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Attachment_CV_AttachmentId",
                table: "AspNetUsers",
                column: "CV_AttachmentId",
                principalTable: "Attachment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Attachment_CV_AttachmentId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Attachment");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CV_AttachmentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CV_AttachmentId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "CV",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
