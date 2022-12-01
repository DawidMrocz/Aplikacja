using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InboxMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inboxs",
                columns: table => new
                {
                    InboxId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CCtr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActTyp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inboxs", x => x.InboxId);
                });

            migrationBuilder.CreateTable(
                name: "InboxItems",
                columns: table => new
                {
                    InboxItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    System = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Engineer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ecm = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    Gpdm = table.Column<int>(type: "int", nullable: false),
                    ProjectNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Client = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Components = table.Column<int>(type: "int", nullable: false),
                    DrawingsComponents = table.Column<int>(type: "int", nullable: false),
                    DrawingsAssembly = table.Column<int>(type: "int", nullable: false),
                    WhenComplete = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Received = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Started = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Finished = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InboxId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InboxItems", x => x.InboxItemId);
                    table.ForeignKey(
                        name: "FK_InboxItems_Inboxs_InboxId",
                        column: x => x.InboxId,
                        principalTable: "Inboxs",
                        principalColumn: "InboxId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InboxItems_InboxId",
                table: "InboxItems",
                column: "InboxId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InboxItems");

            migrationBuilder.DropTable(
                name: "Inboxs");
        }
    }
}
