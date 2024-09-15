namespace SucessoEventos.Entities;

using System.ComponentModel.DataAnnotations;

public class Participante
{
    [Key]
    public int CodPar { get; set; }

    [Required]
    [StringLength(100)]
    public string Nome { get; set; } = default!;

    [Required]
    [DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }

    [Required]
    [Phone]
    public string Telefone { get; set; } = default!;

    // Navegação
    public ICollection<AxParticipantePacote> AxParticipantePacotes { get; set; } = default!;
    public ICollection<AxParticipanteAtividade> AxParticipanteAtividades { get; set; } = default!;
}