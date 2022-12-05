using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaportsMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Raports",
                columns: table => new
                {
                    RaportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalHours = table.Column<double>(type: "float", nullable: false),
                    Created = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raports", x => x.RaportId);
                });

            migrationBuilder.CreateTable(
                name: "UserRaports",
                columns: table => new
                {
                    UserRaportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaportId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAllHours = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRaports", x => x.UserRaportId);
                    table.ForeignKey(
                        name: "FK_UserRaports_Raports_RaportId",
                        column: x => x.RaportId,
                        principalTable: "Raports",
                        principalColumn: "RaportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRaportRecords",
                columns: table => new
                {
                    UserRaportRecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRaportId = table.Column<int>(type: "int", nullable: false),
                    InboxItemId = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    System = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ecm = table.Column<int>(type: "int", nullable: false),
                    Gpdm = table.Column<int>(type: "int", nullable: false),
                    ProjectNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Client = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Components = table.Column<int>(type: "int", nullable: false),
                    DrawingsOfComponents = table.Column<int>(type: "int", nullable: false),
                    DrawingsOfAssemblies = table.Column<int>(type: "int", nullable: false),
                    TaskHours = table.Column<double>(type: "float", nullable: false),
                    DueDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Started = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Finished = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRaportRecords", x => x.UserRaportRecordId);
                    table.ForeignKey(
                        name: "FK_UserRaportRecords_UserRaports_UserRaportId",
                        column: x => x.UserRaportId,
                        principalTable: "UserRaports",
                        principalColumn: "UserRaportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRaportRecords_UserRaportId",
                table: "UserRaportRecords",
                column: "UserRaportId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRaports_RaportId",
                table: "UserRaports",
                column: "RaportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRaportRecords");

            migrationBuilder.DropTable(
                name: "UserRaports");

            migrationBuilder.DropTable(
                name: "Raports");
        }
    }
}
