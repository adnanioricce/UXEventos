namespace SucessoEventos.Web.Models;

using System.ComponentModel.DataAnnotations;


public class InscricaoModel
{
    [Required(ErrorMessage = "Nome é obrigatório")]
    public string Nome { get; set; } = default!;

    [Required(ErrorMessage = "Data de Nascimento é obrigatória")]
    [DataType(DataType.Date)]
    public string DataNascimento { get; set; } = default!;

    [Required(ErrorMessage = "Telefone é obrigatório")]
    [Phone(ErrorMessage = "Formato de telefone inválido")]
    public string Telefone { get; set; } = default!;

    [Required(ErrorMessage = "Selecione um pacote")]
    public int PacoteId { get; set; }    
    public List<int> AtividadesSelecionadas { get; set; } = new List<int>();
}