using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace execution.Migrations
{
    /// <inheritdoc />
    [DbContext(typeof(CscsDbContext))]
    [Migration("20260920232000_AddUserAcademicTerm")]
    public partial class AddUserAcademicTerm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AcademicYear",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 2026);

            migrationBuilder.AddColumn<int>(
                name: "Semester",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 30);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcademicYear",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Semester",
                table: "Users");
        }
    }
}
