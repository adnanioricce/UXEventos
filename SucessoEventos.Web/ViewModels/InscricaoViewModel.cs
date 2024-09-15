namespace SucessoEventos.Web.ViewModels;

using Microsoft.AspNetCore.Mvc.Rendering;
using SucessoEventos.Entities;
using SucessoEventos.Web.Models;

public class InscricaoViewModel
{
    public InscricaoModel Inscricao { get; set; } = default!;
    public SelectList Pacotes { get; set; } = default!;
    public List<SelectListItem> Atividades { get; set; } = [new ("Selecione","")];    
}