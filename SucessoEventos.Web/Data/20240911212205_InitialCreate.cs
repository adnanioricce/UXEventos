using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SucessoEventos.Web.Data
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    DescAtv = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
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
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
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
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participantes", x => x.CodPar);
                });

            migrationBuilder.CreateTable(
                name: "AxParticipanteAtividades",
                columns: table => new
                {
                    CodPar = table.Column<int>(type: "int", nullable: false),
                    CodAtv = table.Column<int>(type: "int", nullable: false),
                    ParticipanteCodPar = table.Column<int>(type: "int", nullable: false),
                    AtividadeCodAtv = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AxParticipanteAtividades", x => new { x.CodPar, x.CodAtv });
                    table.ForeignKey(
                        name: "FK_AxParticipanteAtividades_Atividades_AtividadeCodAtv",
                        column: x => x.AtividadeCodAtv,
                        principalTable: "Atividades",
                        principalColumn: "CodAtv",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AxParticipanteAtividades_Participantes_ParticipanteCodPar",
                        column: x => x.ParticipanteCodPar,
                        principalTable: "Participantes",
                        principalColumn: "CodPar",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AxParticipantePacotes",
                columns: table => new
                {
                    CodPar = table.Column<int>(type: "int", nullable: false),
                    CodPacote = table.Column<int>(type: "int", nullable: false),
                    ParticipanteCodPar = table.Column<int>(type: "int", nullable: false),
                    PacoteCodPacote = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AxParticipantePacotes", x => new { x.CodPar, x.CodPacote });
                    table.ForeignKey(
                        name: "FK_AxParticipantePacotes_Pacotes_PacoteCodPacote",
                        column: x => x.PacoteCodPacote,
                        principalTable: "Pacotes",
                        principalColumn: "CodPacote",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AxParticipantePacotes_Participantes_ParticipanteCodPar",
                        column: x => x.ParticipanteCodPar,
                        principalTable: "Participantes",
                        principalColumn: "CodPar",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AxParticipanteAtividades_AtividadeCodAtv",
                table: "AxParticipanteAtividades",
                column: "AtividadeCodAtv");

            migrationBuilder.CreateIndex(
                name: "IX_AxParticipanteAtividades_ParticipanteCodPar",
                table: "AxParticipanteAtividades",
                column: "ParticipanteCodPar");

            migrationBuilder.CreateIndex(
                name: "IX_AxParticipantePacotes_PacoteCodPacote",
                table: "AxParticipantePacotes",
                column: "PacoteCodPacote");

            migrationBuilder.CreateIndex(
                name: "IX_AxParticipantePacotes_ParticipanteCodPar",
                table: "AxParticipantePacotes",
                column: "ParticipanteCodPar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AxParticipanteAtividades");

            migrationBuilder.DropTable(
                name: "AxParticipantePacotes");

            migrationBuilder.DropTable(
                name: "Atividades");

            migrationBuilder.DropTable(
                name: "Pacotes");

            migrationBuilder.DropTable(
                name: "Participantes");
        }
    }
}
