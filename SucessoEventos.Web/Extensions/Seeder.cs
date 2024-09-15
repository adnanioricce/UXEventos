using SucessoEventos.Entities;

namespace SucessoEventos.Web.Extensions;

public static class Seeder
{
    public static void SeedPacotes(this AppDbContext context)
    {
        if (context.Pacotes.Any())
            return;
        
        var pacotes = new List<Pacote>
        {
            new () { Preco = 220.00m,DataViradaPreco = DateTime.Now.AddDays(5), Descricao = "Sócio" },
            new () { Preco = 400.00m,DataViradaPreco = DateTime.Now.AddDays(5), Descricao = "Não Sócio" },
            new () { Preco = 300.00m,DataViradaPreco = DateTime.Now.AddDays(5), Descricao = "VIP" }
        };

        context.Pacotes.AddRange(pacotes);
        context.SaveChanges();
        
    }

    public static void SeedAtividades(this AppDbContext context)
    {
        if (context.Atividades.Any())
            return;
        
        var atividades = new List<Atividade>
        {
            new () { DescAtv = "Workshop de C# Avançado", Vagas = 30, Preco = 150.00m },
            new () { DescAtv = "Palestra sobre ASP.NET Core", Vagas = 50, Preco = 100.00m },
            new () { DescAtv = "Hackathon de 24 horas", Vagas = 20, Preco = 200.00m }
        };

        context.Atividades.AddRange(atividades);
        context.SaveChanges();
        
    }

    public static void SeedParticipantes(this AppDbContext context)
    {
        if (context.Participantes.Any())
            return;
        
        var participantes = new List<Participante>
        {
            new ()
            {
                Nome = "Adnan Gonzaga",
                DataNascimento = new DateTime(1995, 4, 23),
                Telefone = "(11) 99999-9999"
            },
            new ()
            {
                Nome = "João Silva",
                DataNascimento = new DateTime(1990, 7, 15),
                Telefone = "(11) 98888-8888"
            },
            new ()
            {
                Nome = "Maria Souza",
                DataNascimento = new DateTime(1985, 10, 30),
                Telefone = "(21) 97777-7777"
            }
        };

        context.Participantes.AddRange(participantes);
        context.SaveChanges();

        // Associações de Participantes a Pacotes e Atividades
        SeedAxParticipantePacote(context);
        SeedAxParticipanteAtividade(context);
        
    }

    public static void SeedAxParticipantePacote(this AppDbContext context)
    {
        var associacoesPacote = new List<AxParticipantePacote>
        {
            new () { CodPar = 1, CodPacote = 1 }, // Adnan é Sócio
            new () { CodPar = 2, CodPacote = 2 }, // João é Não Sócio
            new () { CodPar = 3, CodPacote = 3 }  // Maria é VIP
        };

        context.AxParticipantePacote.AddRange(associacoesPacote);
        context.SaveChanges();
    }

    public static void SeedAxParticipanteAtividade(this AppDbContext context)
    {
        var associacoesAtividade = new List<AxParticipanteAtividade>
        {
            new () { CodPar = 1, CodAtv = 1 },
            new () { CodPar = 2, CodAtv = 2 },
            new () { CodPar = 3, CodAtv = 3 },
            new () { CodPar = 3, CodAtv = 1 } 
        };

        context.AxParticipanteAtividade.AddRange(associacoesAtividade);
        context.SaveChanges();
    }
    public static void SeedDatabase(this WebApplication app)
    {
        using var sc = app.Services.CreateScope();
        using var ctx = sc.ServiceProvider.GetRequiredService<AppDbContext>();
        SeedPacotes(ctx);
        SeedAtividades(ctx);
        SeedParticipantes(ctx);
    }
}