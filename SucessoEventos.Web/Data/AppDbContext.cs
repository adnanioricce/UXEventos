using Microsoft.EntityFrameworkCore;

namespace SucessoEventos.Entities;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Participante> Participantes { get; set; }
    public DbSet<Pacote> Pacotes { get; set; }
    public DbSet<Atividade> Atividades { get; set; }
    public DbSet<AxParticipantePacote> AxParticipantePacote { get; set; }
    public DbSet<AxParticipanteAtividade> AxParticipanteAtividade { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurações específicas
        modelBuilder.Entity<AxParticipantePacote>()
            .HasKey(ap => new { ap.CodPar, ap.CodPacote });

        modelBuilder.Entity<AxParticipanteAtividade>()
            .HasKey(aa => new { aa.CodPar, aa.CodAtv });
    }
}