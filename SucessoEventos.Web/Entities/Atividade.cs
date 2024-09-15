using System.ComponentModel.DataAnnotations;

namespace SucessoEventos.Entities;

public class Atividade
{
    [Key]
    public int CodAtv { get; set; }

    [Required]
    [StringLength(200)]
    public string DescAtv { get; set; } = default!;

    [Required]
    public int Vagas { get; set; }

    [Required]
    [DataType(DataType.Currency)]
    public decimal Preco { get; set; }
    
}