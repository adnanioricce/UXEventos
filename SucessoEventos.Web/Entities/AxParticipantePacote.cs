namespace SucessoEventos.Entities;

using SucessoEventos.Entities;

public class AxParticipantePacote
{
    public int CodPar { get; set; }
    public int CodPacote { get; set; }

    // Navegação
    public Participante Participante { get; set; } = default!;
    public Pacote Pacote { get; set; } = default!;
}