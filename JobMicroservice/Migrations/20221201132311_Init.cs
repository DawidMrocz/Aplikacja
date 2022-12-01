using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobDescription = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    System = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Engineer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ecm = table.Column<int>(type: "int", nullable: false),
                    Gpdm = table.Column<int>(type: "int", nullable: false),
                    ProjectNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Client = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Received = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Started = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Finished = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhenComplete = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobId);
                });

            migrationBuilder.CreateTable(
                name: "UserJobs",
                columns: table => new
                {
                    UserJobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJobs", x => x.UserJobId);
                    table.ForeignKey(
                        name: "FK_UserJobs_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "JobId");
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "Client", "DueDate", "Ecm", "Engineer", "Finished", "Gpdm", "JobDescription", "Link", "ProjectName", "ProjectNumber", "Received", "Started", "Status", "System", "Type", "WhenComplete" },
                values: new object[,]
                {
                    { 1, "TOYOTA", null, 4561976, "Agata", null, 1, "Create drawing", "linkt o task", "sap text", "LASDl", "15.22.2022", null, "2D", "Catia", "2D", null },
                    { 2, "TOYOTA", "25.11.2022", 4561976, "Agata", null, 1, "Create drawing", "linkt o task", "sap text", "LASDl", "20.11.2022", null, "2D", "Catia", "2D", null },
                    { 3, "TOYOTA", null, 4561976, "Agata", null, 1, "Create drawing", "linkt o task", "sap text", "LASDl", "20.11.2022", null, "2D", "Catia", "2D", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserJobs_JobId",
                table: "UserJobs",
                column: "JobId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserJobs");

            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
