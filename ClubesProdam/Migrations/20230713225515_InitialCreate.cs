using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubesProdam.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_estabelecimentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    cep = table.Column<string>(type: "varchar(10)", nullable: false),
                    cnpj = table.Column<string>(type: "varchar(15)", nullable: false),
                    tipo_estabelecimento = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_estabelecimentos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_funcionarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salario = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    idade = table.Column<int>(type: "int", nullable: false),
                    id_estabelecimento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_funcionarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_funcionarios_tb_estabelecimentos_id_estabelecimento",
                        column: x => x.id_estabelecimento,
                        principalTable: "tb_estabelecimentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_funcionarios_id_estabelecimento",
                table: "tb_funcionarios",
                column: "id_estabelecimento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_funcionarios");

            migrationBuilder.DropTable(
                name: "tb_estabelecimentos");
        }
    }
}
