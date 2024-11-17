using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fbb.Migrations
{
    /// <inheritdoc />
    public partial class KnownASCorrected : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KnownAS",
                table: "AspNetUsers",
                newName: "KnownAs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KnownAs",
                table: "AspNetUsers",
                newName: "KnownAS");
        }
    }
}
