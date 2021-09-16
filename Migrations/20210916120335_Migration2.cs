using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ProductsApi.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoFornecedores_Fornecedores_FornecedorId",
                table: "ProdutoFornecedores");

            migrationBuilder.DropIndex(
                name: "IX_ProdutoFornecedores_FornecedorId",
                table: "ProdutoFornecedores");

            migrationBuilder.AddColumn<Guid>(
                name: "FornecedorId1",
                table: "ProdutoFornecedores",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FornecedorId",
                table: "Fornecedores",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoFornecedores_FornecedorId1",
                table: "ProdutoFornecedores",
                column: "FornecedorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoFornecedores_Fornecedores_FornecedorId1",
                table: "ProdutoFornecedores",
                column: "FornecedorId1",
                principalTable: "Fornecedores",
                principalColumn: "FornecedorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoFornecedores_Fornecedores_FornecedorId1",
                table: "ProdutoFornecedores");

            migrationBuilder.DropIndex(
                name: "IX_ProdutoFornecedores_FornecedorId1",
                table: "ProdutoFornecedores");

            migrationBuilder.DropColumn(
                name: "FornecedorId1",
                table: "ProdutoFornecedores");

            migrationBuilder.AlterColumn<int>(
                name: "FornecedorId",
                table: "Fornecedores",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoFornecedores_FornecedorId",
                table: "ProdutoFornecedores",
                column: "FornecedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoFornecedores_Fornecedores_FornecedorId",
                table: "ProdutoFornecedores",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "FornecedorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
