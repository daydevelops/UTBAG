using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TBAG.Migrations
{
    /// <inheritdoc />
    public partial class CreateSavesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Saves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saves", x => x.Id);
                }
            );
            
            migrationBuilder.Sql(@"
                CREATE TRIGGER UpdateSaveLastUpdated
                AFTER UPDATE ON Saves
                FOR EACH ROW
                BEGIN
                    UPDATE Saves SET LastUpdated = CURRENT_TIMESTAMP WHERE Id = OLD.Id;
                END;
            ");
        
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS UpdateSaveLastUpdated");
            migrationBuilder.DropTable(
                name: "Saves");
        }
    }
}