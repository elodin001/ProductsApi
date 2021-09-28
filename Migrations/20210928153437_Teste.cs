using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductsApi.Migrations
{
    public partial class Teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    FornecedorId = table.Column<Guid>(type: "uuid", nullable: false),
                    CNPJ = table.Column<int>(type: "integer", nullable: false),
                    RazaoSocial = table.Column<string>(type: "text", nullable: true),
                    NomeFantasia = table.Column<string>(type: "text", nullable: true),
                    Endereco = table.Column<string>(type: "text", nullable: true),
                    Cidade = table.Column<string>(type: "text", nullable: true),
                    Estado = table.Column<string>(type: "text", nullable: true),
                    CEP = table.Column<int>(type: "integer", nullable: false),
                    Telefone = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.FornecedorId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    Preco = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    Categoria = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoFornecedores",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoFornecedores", x => new { x.ProductId, x.FornecedorId });
                    table.ForeignKey(
                        name: "FK_ProdutoFornecedores_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "FornecedorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutoFornecedores_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoFornecedores_FornecedorId",
                table: "ProdutoFornecedores",
                column: "FornecedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoFornecedores");

            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
