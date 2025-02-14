using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinTrack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    SenhaHash = table.Column<string>(type: "text", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AplicacoesFinanceiras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    Observacao = table.Column<string>(type: "text", nullable: true),
                    DataRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AplicacoesFinanceiras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AplicacoesFinanceiras_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ControlesMensais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uuid", nullable: false),
                    Mes = table.Column<string>(type: "text", nullable: false),
                    Ano = table.Column<string>(type: "text", nullable: false),
                    Observacao = table.Column<string>(type: "text", nullable: true),
                    TotalCreditos = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalDebitos = table.Column<decimal>(type: "numeric", nullable: false),
                    Saldo = table.Column<decimal>(type: "numeric", nullable: false),
                    DataRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlesMensais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlesMensais_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DebitosMensais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    Observacao = table.Column<string>(type: "text", nullable: true),
                    DataRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Pago = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebitosMensais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DebitosMensais_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FontesPagamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    Observacao = table.Column<string>(type: "text", nullable: true),
                    DataRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FontesPagamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FontesPagamento_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoAplicacoesFinanceiras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AplicacaoFinanceiraId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ValorHistorico = table.Column<int>(type: "integer", nullable: false),
                    Credito = table.Column<bool>(type: "boolean", nullable: false),
                    Debito = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoAplicacoesFinanceiras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoAplicacoesFinanceiras_AplicacoesFinanceiras_Aplica~",
                        column: x => x.AplicacaoFinanceiraId,
                        principalTable: "AplicacoesFinanceiras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ControleMensalDebitos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdDebitoMensal = table.Column<Guid>(type: "uuid", nullable: false),
                    IdControleMensal = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControleMensalDebitos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControleMensalDebitos_ControlesMensais_IdControleMensal",
                        column: x => x.IdControleMensal,
                        principalTable: "ControlesMensais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ControleMensalDebitos_DebitosMensais_IdDebitoMensal",
                        column: x => x.IdDebitoMensal,
                        principalTable: "DebitosMensais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ControleMensalCreditos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdFontePagamento = table.Column<Guid>(type: "uuid", nullable: false),
                    IdControleMensal = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControleMensalCreditos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControleMensalCreditos_ControlesMensais_IdControleMensal",
                        column: x => x.IdControleMensal,
                        principalTable: "ControlesMensais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ControleMensalCreditos_FontesPagamento_IdFontePagamento",
                        column: x => x.IdFontePagamento,
                        principalTable: "FontesPagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AplicacoesFinanceiras_IdUsuario",
                table: "AplicacoesFinanceiras",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ControleMensalCreditos_IdControleMensal",
                table: "ControleMensalCreditos",
                column: "IdControleMensal");

            migrationBuilder.CreateIndex(
                name: "IX_ControleMensalCreditos_IdFontePagamento",
                table: "ControleMensalCreditos",
                column: "IdFontePagamento");

            migrationBuilder.CreateIndex(
                name: "IX_ControleMensalDebitos_IdControleMensal",
                table: "ControleMensalDebitos",
                column: "IdControleMensal");

            migrationBuilder.CreateIndex(
                name: "IX_ControleMensalDebitos_IdDebitoMensal",
                table: "ControleMensalDebitos",
                column: "IdDebitoMensal");

            migrationBuilder.CreateIndex(
                name: "IX_ControlesMensais_IdUsuario",
                table: "ControlesMensais",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_DebitosMensais_IdUsuario",
                table: "DebitosMensais",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_FontesPagamento_IdUsuario",
                table: "FontesPagamento",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoAplicacoesFinanceiras_AplicacaoFinanceiraId",
                table: "HistoricoAplicacoesFinanceiras",
                column: "AplicacaoFinanceiraId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControleMensalCreditos");

            migrationBuilder.DropTable(
                name: "ControleMensalDebitos");

            migrationBuilder.DropTable(
                name: "HistoricoAplicacoesFinanceiras");

            migrationBuilder.DropTable(
                name: "FontesPagamento");

            migrationBuilder.DropTable(
                name: "ControlesMensais");

            migrationBuilder.DropTable(
                name: "DebitosMensais");

            migrationBuilder.DropTable(
                name: "AplicacoesFinanceiras");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
