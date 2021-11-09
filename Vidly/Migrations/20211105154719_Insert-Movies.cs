using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Migrations
{
    public partial class InsertMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Movies (Name, GenreId) VALUES ('Hangover', 5)");
            migrationBuilder.Sql("INSERT INTO Movies (Name, GenreId) VALUES ('Die Hard', 1)");
            migrationBuilder.Sql("INSERT INTO Movies (Name, GenreId) VALUES ('The Terminator', 1)");
            migrationBuilder.Sql("INSERT INTO Movies (Name, GenreId) VALUES ('Toy Story', 3)");
            migrationBuilder.Sql("INSERT INTO Movies (Name, GenreId) VALUES ('Titanic', 4)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
