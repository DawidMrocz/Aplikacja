using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatsApiMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CCtr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActTyp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Cats",
                columns: table => new
                {
                    CatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatCreated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.CatId);
                    table.ForeignKey(
                        name: "FK_Cats_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatRecords",
                columns: table => new
                {
                    CatRecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InboxItemId = table.Column<int>(type: "int", nullable: false),
                    Receiver = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SapText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatRecords", x => x.CatRecordId);
                    table.ForeignKey(
                        name: "FK_CatRecords_Cats_CatId",
                        column: x => x.CatId,
                        principalTable: "Cats",
                        principalColumn: "CatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatRecordHourss",
                columns: table => new
                {
                    CatRecordHoursId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hours = table.Column<double>(type: "float", nullable: false),
                    CatRecordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatRecordHourss", x => x.CatRecordHoursId);
                    table.ForeignKey(
                        name: "FK_CatRecordHourss_CatRecords_CatRecordId",
                        column: x => x.CatRecordId,
                        principalTable: "CatRecords",
                        principalColumn: "CatRecordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatRecordHourss_CatRecordId",
                table: "CatRecordHourss",
                column: "CatRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_CatRecords_CatId",
                table: "CatRecords",
                column: "CatId");

            migrationBuilder.CreateIndex(
                name: "IX_Cats_EmployeeId",
                table: "Cats",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatRecordHourss");

            migrationBuilder.DropTable(
                name: "CatRecords");

            migrationBuilder.DropTable(
                name: "Cats");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
