using Microsoft.EntityFrameworkCore;
using SucessoEventos.Web.Data.Configuration;

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
        new ParticipantesConfiguration()
            .Configure(modelBuilder);
        
    }
}