namespace SucessoEventos.Entities;

public class AxParticipanteAtividade
{
    public int CodPar { get; set; }
    public int CodAtv { get; set; }

    // Navegação
    public Participante Participante { get; set; } = default!;
    public Atividade Atividade { get; set; } = default!;
}