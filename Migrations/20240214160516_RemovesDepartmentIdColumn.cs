using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core_WebApi.Migrations
{
    /// <inheritdoc />
    public partial class RemovesDepartmentIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Employeeinfo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Employeeinfo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
