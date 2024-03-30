using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeContatos.Migrations
{
    public partial class CriacaoTabelaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Contatos",
                table: "Contatos");

            migrationBuilder.RenameTable(
                name: "Contatos",
                newName: "ContatoModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContatoModel",
                table: "ContatoModel",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContatoModel",
                table: "ContatoModel");

            migrationBuilder.RenameTable(
                name: "ContatoModel",
                newName: "Contatos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contatos",
                table: "Contatos",
                column: "Id");
        }
    }
}
