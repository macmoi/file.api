using Microsoft.EntityFrameworkCore.Migrations;

namespace file.Persistance.Migrations
{
    public partial class DummyDataToUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Added dummy data for simplification
            migrationBuilder
                .Sql("INSERT INTO user (name, lastname) VALUES ('Jennifer', 'Lopez')");
            migrationBuilder
                .Sql("INSERT INTO user (name, lastname) VALUES ('Edward', 'Norton')");
            migrationBuilder
                .Sql("INSERT INTO user (name, lastname) VALUES ('Jessica', 'Alba')");
            migrationBuilder
                .Sql("INSERT INTO user (name, lastname) VALUES ('Scarlett', 'Johanson')");
            migrationBuilder
                .Sql("INSERT INTO user (name, lastname) VALUES ('Bruno', 'Mars')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Not the best down method, but for example propose works
            migrationBuilder
                .Sql("DELETE FROM user WHERE id between 1 AND 5");
        }
    }
}
