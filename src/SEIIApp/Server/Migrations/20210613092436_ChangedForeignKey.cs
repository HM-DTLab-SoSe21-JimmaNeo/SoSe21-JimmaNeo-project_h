using Microsoft.EntityFrameworkCore.Migrations;

namespace SEIIApp.Server.Migrations
{
    public partial class ChangedForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonProfilDefinitions_LessonDefinitions_lessonNumber",
                table: "LessonProfilDefinitions");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_LessonDefinitions_lessonNumber",
                table: "LessonDefinitions",
                column: "lessonNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonProfilDefinitions_LessonDefinitions_lessonNumber",
                table: "LessonProfilDefinitions",
                column: "lessonNumber",
                principalTable: "LessonDefinitions",
                principalColumn: "lessonNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonProfilDefinitions_LessonDefinitions_lessonNumber",
                table: "LessonProfilDefinitions");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_LessonDefinitions_lessonNumber",
                table: "LessonDefinitions");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonProfilDefinitions_LessonDefinitions_lessonNumber",
                table: "LessonProfilDefinitions",
                column: "lessonNumber",
                principalTable: "LessonDefinitions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
