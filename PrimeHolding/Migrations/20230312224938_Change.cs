using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimeHolding.Migrations
{
    public partial class Change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeLevel",
                table: "EmployeeToSkill",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeLevel",
                table: "EmployeeToSkill");
        }
    }
}
