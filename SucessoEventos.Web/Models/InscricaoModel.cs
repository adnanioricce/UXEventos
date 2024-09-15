namespace SucessoEventos.Web.Models;

using System.ComponentModel.DataAnnotations;


public class InscricaoModel
{
    [Required(ErrorMessage = "Nome é obrigatório")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Data de Nascimento é obrigatória")]
    [DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }

    [Required(ErrorMessage = "Telefone é obrigatório")]
    [Phone(ErrorMessage = "Formato de telefone inválido")]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "Selecione um pacote")]
    public int PacoteId { get; set; }

    public List<int> AtividadesSelecionadas { get; set; } = new List<int>();
}