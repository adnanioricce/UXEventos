namespace SucessoEventos.Entities;

using System.ComponentModel.DataAnnotations;

public class Participante
{
    [Key]
    public int CodPar { get; set; }

    [Required]
    [StringLength(100)]
    public string Nome { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }

    [Required]
    [Phone]
    public string Telefone { get; set; }

    // Navegação
    public ICollection<AxParticipantePacote> AxParticipantePacotes { get; set; }
    public ICollection<AxParticipanteAtividade> AxParticipanteAtividades { get; set; }
}