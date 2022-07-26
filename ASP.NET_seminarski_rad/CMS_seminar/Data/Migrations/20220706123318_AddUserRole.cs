using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS_seminar.Data.Migrations
{
    public partial class AddUserRole : Migration
    {
        const string USER_ROLE_GUID = "820ba22f-db76-4702-8cfa-9618f56b548c";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('{USER_ROLE_GUID}','User','USER')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM AspNetRoles WHERE Id = '{USER_ROLE_GUID}'");
        }
    }
}
