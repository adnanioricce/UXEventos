namespace SucessoEventos.Web.ViewModels;

using SucessoEventos.Entities;
using SucessoEventos.Web.Models;

public class ConfirmacaoViewModel
{
    public InscricaoModel Inscricao { get; set; } = default!;
    public string PacoteDescricao { get; set; } = default!;
    public List<Atividade> AtividadesSelecionadas { get; set; } = default!;
}