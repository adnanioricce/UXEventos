namespace SucessoEventos.Entities;

using System.ComponentModel.DataAnnotations;

public class Pacote
{
    [Key]
    public int CodPacote { get; set; }

    [Required]
    [DataType(DataType.Currency)]
    public decimal Preco { get; set; }
    public DateTime DataViradaPreco { get; set; } = default!;
    [Required]
    [StringLength(200)]
    public string Descricao { get; set; } = default!;

    public ICollection<AxParticipantePacote> AxParticipantePacotes { get; set; } = default!;
}