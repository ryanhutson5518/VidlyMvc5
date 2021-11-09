using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Migrations
{
    public partial class UpdatePopulateMembershipTypeColName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                UPDATE MemberShipType
                SET Name = 'Pay as You Go'
                WHERE Id = 1");

            migrationBuilder.Sql(@"
                UPDATE MemberShipType
                SET Name = 'Monthly'
                WHERE Id = 2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
