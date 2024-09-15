namespace SucessoEventos.Web.ViewModels;

using Microsoft.AspNetCore.Mvc.Rendering;
using SucessoEventos.Entities;
using SucessoEventos.Web.Models;

public class InscricaoViewModel
{
    public InscricaoModel Inscricao { get; set; }
    public SelectList Pacotes { get; set; }
    public List<Atividade> Atividades { get; set; }
}