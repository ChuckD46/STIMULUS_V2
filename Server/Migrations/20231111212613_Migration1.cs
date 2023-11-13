using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STIMULUS_V2.Server.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TokenInfo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Identifiant = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Identifiant);
                    table.ForeignKey(
                        name: "FK_Admin_Utilisateur_Identifiant",
                        column: x => x.Identifiant,
                        principalTable: "Utilisateur",
                        principalColumn: "Identifiant");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TokenInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
