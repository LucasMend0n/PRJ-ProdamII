using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubesProdam.Migrations
{
    /// <inheritdoc />
    public partial class FinalConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_funcionarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_funcionarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_estabelecimento = table.Column<int>(type: "int", nullable: false),
                    idade = table.Column<int>(type: "int", nullable: false),
                    nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    salario = table.Column<decimal>(type: "decimal(7,2)", nullable: false)
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
    }
}
