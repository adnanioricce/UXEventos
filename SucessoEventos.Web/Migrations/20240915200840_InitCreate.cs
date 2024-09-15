using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SucessoEventos.Web.Migrations
{
    /// <inheritdoc />
    public partial class InitCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atividades",
                columns: table => new
                {
                    CodAtv = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescAtv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Vagas = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividades", x => x.CodAtv);
                });

            migrationBuilder.CreateTable(
                name: "Pacotes",
                columns: table => new
                {
                    CodPacote = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataViradaPreco = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacotes", x => x.CodPacote);
                });

            migrationBuilder.CreateTable(
                name: "Participantes",
                columns: table => new
                {
                    CodPar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participantes", x => x.CodPar);
                });

            migrationBuilder.CreateTable(
                name: "AxParticipanteAtividade",
                columns: table => new
                {
                    CodPar = table.Column<int>(type: "int", nullable: false),
                    CodAtv = table.Column<int>(type: "int", nullable: false),
                    ParticipanteCodPar = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AxParticipanteAtividade", x => new { x.CodPar, x.CodAtv });
                    table.ForeignKey(
                        name: "FK_AxParticipanteAtividade_Atividades_CodAtv",
                        column: x => x.CodAtv,
                        principalTable: "Atividades",
                        principalColumn: "CodAtv",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AxParticipanteAtividade_Participantes_CodPar",
                        column: x => x.CodPar,
                        principalTable: "Participantes",
                        principalColumn: "CodPar",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AxParticipanteAtividade_Participantes_ParticipanteCodPar",
                        column: x => x.ParticipanteCodPar,
                        principalTable: "Participantes",
                        principalColumn: "CodPar");
                });

            migrationBuilder.CreateTable(
                name: "AxParticipantePacote",
                columns: table => new
                {
                    CodPar = table.Column<int>(type: "int", nullable: false),
                    CodPacote = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AxParticipantePacote", x => new { x.CodPar, x.CodPacote });
                    table.ForeignKey(
                        name: "FK_AxParticipantePacote_Pacotes_CodPacote",
                        column: x => x.CodPacote,
                        principalTable: "Pacotes",
                        principalColumn: "CodPacote",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AxParticipantePacote_Participantes_CodPar",
                        column: x => x.CodPar,
                        principalTable: "Participantes",
                        principalColumn: "CodPar",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AxParticipanteAtividade_CodAtv",
                table: "AxParticipanteAtividade",
                column: "CodAtv");

            migrationBuilder.CreateIndex(
                name: "IX_AxParticipanteAtividade_ParticipanteCodPar",
                table: "AxParticipanteAtividade",
                column: "ParticipanteCodPar");

            migrationBuilder.CreateIndex(
                name: "IX_AxParticipantePacote_CodPacote",
                table: "AxParticipantePacote",
                column: "CodPacote");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AxParticipanteAtividade");

            migrationBuilder.DropTable(
                name: "AxParticipantePacote");

            migrationBuilder.DropTable(
                name: "Atividades");

            migrationBuilder.DropTable(
                name: "Pacotes");

            migrationBuilder.DropTable(
                name: "Participantes");
        }
    }
}
