using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace execution.Migrations
{
    /// <inheritdoc />
    [DbContext(typeof(CscsDbContext))]
    [Migration("20260920225000_AddUserInstitution")]
    public partial class AddUserInstitution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Institution",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 10);

            migrationBuilder.Sql("""
                UPDATE "Users"
                SET "Institution" = CASE
                    WHEN lower("Email") LIKE '%@mst.edu' THEN 10
                    WHEN lower("Email") LIKE '%@umsystem.edu' THEN 20
                    ELSE 10
                END;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Institution",
                table: "Users");
        }
    }
}
