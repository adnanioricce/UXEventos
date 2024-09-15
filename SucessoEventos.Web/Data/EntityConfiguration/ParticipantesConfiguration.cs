using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SucessoEventos.Entities;

namespace SucessoEventos.Web.Data.Configuration;

public class ParticipantesConfiguration
//existe essa opção, mas eu prefiro ir pelo caminho de passar o ModelBuilder como dependência
// e criar os mappings a partir dele, porque:
// 1 - Como eu não estou fazendo uma aplicação inteira, isso ajuda
// 2 - Me permite fazer mapeamentos por dominio: configuração dos Participantes(Tabela participante,Convidados e etc), Das Salas de eventos(Sala,Pacote e Atividades) e etc.
// : IEntityTypeConfiguration<Participante>
{
    public void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Participante>(entity => {
                entity.ToTable("Participantes");
                
                entity.HasKey(e => e.CodPar);

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .IsRequired();

                entity.Property(e => e.DataNascimento)
                    .IsRequired();

                entity.Property(e => e.Telefone)
                    .HasMaxLength(20)
                    .IsRequired();
            });
        modelBuilder.Entity<Pacote>(entity =>
        {
            entity.HasKey(e => e.CodPacote);

            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(e => e.Preco)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();

            entity.Property(e => e.DataViradaPreco)
                .IsRequired();
        });
         // Mapeamento da tabela Atividades
        modelBuilder.Entity<Atividade>(entity =>
        {
            entity.HasKey(e => e.CodAtv);

            entity.Property(e => e.DescAtv)
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(e => e.Vagas)
                .IsRequired();

            entity.Property(e => e.Preco)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();
        });
         // Mapeamento da tabela AxParticipantePacote (tabela de associação)
        modelBuilder.Entity<AxParticipantePacote>(entity =>
        {
            entity.HasKey(e => new { e.CodPar, e.CodPacote });

            entity.HasOne(e => e.Participante)
                .WithMany(p => p.AxParticipantePacotes)
                .HasForeignKey(e => e.CodPar);

            entity.HasOne(e => e.Pacote)
                .WithMany(p => p.AxParticipantePacotes)
                .HasForeignKey(e => e.CodPacote);
        });

        // Mapeamento da tabela AxParticipanteAtividade (tabela de associação)
        modelBuilder.Entity<AxParticipanteAtividade>(entity =>
        {
            entity.HasKey(e => new { e.CodPar, e.CodAtv });

            entity.HasOne(e => e.Participante)
                // .WithMany(p => p.AxParticipanteAtividades)
                .WithMany()
                .HasForeignKey(e => e.CodPar);

            entity.HasOne(e => e.Atividade)
                .WithMany()
                .HasForeignKey(e => e.CodAtv);
        });
        // modelBuilder.Entity<AxParticipantePacote>()
        //     .ToTable("AxParticipantePacote")
        //     .HasKey(ap => new { ap.CodPar, ap.CodPacote });

        // modelBuilder.Entity<AxParticipanteAtividade>()
        //     .ToTable("AxParticipanteAtividade")
        //     .HasKey(aa => new { aa.CodPar, aa.CodAtv });
    }
}