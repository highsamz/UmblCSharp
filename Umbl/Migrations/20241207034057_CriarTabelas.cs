using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Umbl.Migrations
{
    /// <inheritdoc />
    public partial class CriarTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnderecosPontoColeta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Logradouro = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cep = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Numero = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Bairro = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Estado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecosPontoColeta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PontosColeta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Capacidade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EnderecoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MateriaisAceitos = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontosColeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PontosColeta_EnderecosPontoColeta_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "EnderecosPontoColeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PontosColeta_EnderecoId",
                table: "PontosColeta",
                column: "EnderecoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PontosColeta");

            migrationBuilder.DropTable(
                name: "EnderecosPontoColeta");
        }
    }
}
