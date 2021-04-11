using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioRDI.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVV",
                table: "cards");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CVV",
                table: "cards",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
