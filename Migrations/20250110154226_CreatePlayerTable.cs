using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TBAG.Migrations
{
    /// <inheritdoc />
    public partial class CreatePlayerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SaveId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentScene = table.Column<string>(type: "TEXT", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Saves_SaveId", // Name of the FK constraint
                        column: x => x.SaveId, // FK column
                        principalTable: "Saves", // Referenced table
                        principalColumn: "Id", // Referenced column
                        onDelete: ReferentialAction.Cascade // Delete behavior
                    );
                }
            );
            
            migrationBuilder.Sql(@"
                CREATE TRIGGER UpdatePlayersLastUpdated
                AFTER UPDATE ON Players
                FOR EACH ROW
                BEGIN
                    UPDATE Saves SET LastUpdated = CURRENT_TIMESTAMP WHERE Id = OLD.Id;
                END;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS UpdatePlayersLastUpdated");
            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
