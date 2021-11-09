using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Migrations
{
    public partial class PopulateCustomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO Customers (Name, IsSubscribedToNewsLetter, MembershipTypeId)
                VALUES ('John Smith', 0, 1)");

            migrationBuilder.Sql(@"
                INSERT INTO Customers (Name, IsSubscribedToNewsLetter, MembershipTypeId)
                VALUES ('Mary Williams', 1, 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
