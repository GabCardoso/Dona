using Microsoft.EntityFrameworkCore.Migrations;

namespace Dona.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(maxLength: 128, nullable: false),
                    Email = table.Column<string>(maxLength: 128, nullable: false),
                    Senha = table.Column<string>(maxLength: 128, nullable: false),
                    Telefone = table.Column<string>(maxLength: 128, nullable: true),
                    Uf = table.Column<string>(maxLength: 2, nullable: false),
                    Profissao = table.Column<string>(maxLength: 128, nullable: false),
                    SenhaHash = table.Column<byte[]>(maxLength: 128, nullable: false),
                    SenhaSalt = table.Column<byte[]>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarias", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarias");
        }
    }
}
