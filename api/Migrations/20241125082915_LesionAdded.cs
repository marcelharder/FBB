using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fbb.Migrations
{
    /// <inheritdoc />
    public partial class LesionAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lesion",
                table: "CaseReports",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lesion",
                table: "CaseReports");
        }
    }
}
