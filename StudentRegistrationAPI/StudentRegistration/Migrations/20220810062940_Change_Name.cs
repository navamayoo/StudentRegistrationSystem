using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentRegistration.Migrations
{
    public partial class Change_Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectName",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "ClassName",
                table: "Classes");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Subjects",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Classes",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Classes");

            migrationBuilder.AddColumn<string>(
                name: "SubjectName",
                table: "Subjects",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClassName",
                table: "Classes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
