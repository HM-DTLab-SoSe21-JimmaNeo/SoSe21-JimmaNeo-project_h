using Microsoft.EntityFrameworkCore.Migrations;

namespace SEIIApp.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LessonDefinitions",
                columns: table => new
                {
                    lessonNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lessonTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    videoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonDefinitions", x => x.lessonNumber);
                });

            migrationBuilder.CreateTable(
                name: "MessageDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    senderId = table.Column<int>(type: "int", nullable: false),
                    senderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    receiverId = table.Column<int>(type: "int", nullable: false),
                    receiverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unread = table.Column<bool>(type: "bit", nullable: false),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfilDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilDefinitions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonDefinitions");

            migrationBuilder.DropTable(
                name: "MessageDefinitions");

            migrationBuilder.DropTable(
                name: "ProfilDefinitions");
        }
    }
}
