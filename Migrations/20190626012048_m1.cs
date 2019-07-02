using Microsoft.EntityFrameworkCore.Migrations;

namespace _functions.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    School = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "FirstName", "LastName", "School" },
                values: new object[,]
                {
                    { "4ceab280-96ba-4c2a-911b-5af687a641a4", "Jane", "Smith", "Medicine" },
                    { "8ebb5891-b7ca-48f8-bd74-88de7513c6d0", "John", "Fisher", "Engineering" },
                    { "4f00688f-1c03-4255-bcb0-025b9221c0d7", "Pamela", "Baker", "Food Science" },
                    { "e5dd769d-55d1-49a0-9f79-d8ae3cf9c474", "Peter", "Taylor", "Mining" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
