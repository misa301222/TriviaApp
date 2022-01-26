using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TriviaApp.Data.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    Option = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => new { x.Id, x.QuestionId });
                });

            migrationBuilder.CreateTable(
                name: "UserScore",
                columns: table => new
                {
                    GeneratedName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Right = table.Column<int>(type: "int", nullable: false),
                    Wrong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserScore", x => new { x.GeneratedName, x.Email });
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    GeneratedName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuestionForeignKeyId = table.Column<int>(type: "int", nullable: false),
                    QuestionForeignKeyQuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => new { x.Id, x.GeneratedName });
                    table.ForeignKey(
                        name: "FK_Room_Question_QuestionForeignKeyId_QuestionForeignKeyQuestionId",
                        columns: x => new { x.QuestionForeignKeyId, x.QuestionForeignKeyQuestionId },
                        principalTable: "Question",
                        principalColumns: new[] { "Id", "QuestionId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Room_QuestionForeignKeyId_QuestionForeignKeyQuestionId",
                table: "Room",
                columns: new[] { "QuestionForeignKeyId", "QuestionForeignKeyQuestionId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "UserScore");

            migrationBuilder.DropTable(
                name: "Question");
        }
    }
}
