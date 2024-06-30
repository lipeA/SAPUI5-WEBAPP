using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back.Migrations
{
    /// <inheritdoc />
    public partial class removerNotaClienteEFornecedor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NotaFiscal_ClienteId",
                table: "NotaFiscal");

            migrationBuilder.DropIndex(
                name: "IX_NotaFiscal_FornecedorId",
                table: "NotaFiscal");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscal_ClienteId",
                table: "NotaFiscal",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscal_FornecedorId",
                table: "NotaFiscal",
                column: "FornecedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NotaFiscal_ClienteId",
                table: "NotaFiscal");

            migrationBuilder.DropIndex(
                name: "IX_NotaFiscal_FornecedorId",
                table: "NotaFiscal");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscal_ClienteId",
                table: "NotaFiscal",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscal_FornecedorId",
                table: "NotaFiscal",
                column: "FornecedorId",
                unique: true);
        }
    }
}
