using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace execution.Migrations
{
    /// <inheritdoc />
    [DbContext(typeof(CscsDbContext))]
    [Migration("20260920231000_AddUserInstitutionId")]
    public partial class AddUserInstitutionId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InstitutionId",
                table: "Users",
                type: "character varying(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.Sql("""
                UPDATE "Users"
                SET "InstitutionId" = CASE
                    WHEN "Institution" = 10 THEN 'mst'
                    WHEN "Institution" = 20 THEN 'umsystem'
                    ELSE NULL
                END
                WHERE "InstitutionId" IS NULL;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstitutionId",
                table: "Users");
        }
    }
}
