using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SucessoEventos.Entities;
using SucessoEventos.Web.Models;
using SucessoEventos.Web.ViewModels;

namespace SucessoEventos.Web.Controllers;

public class InscricaoController : Controller
{
    private readonly AppDbContext _context;

    public InscricaoController(AppDbContext context)
    {
        _context = context;
    }

    // GET: Inscricao/Create
    public IActionResult Create()
    {
        var viewModel = new InscricaoViewModel
        {
            Inscricao = new InscricaoModel(),
            Pacotes = new SelectList(_context.Pacotes.ToList(), "CodPacote", "Descricao"),
            Atividades = _context.Atividades.ToList()
        };

        return View(viewModel);
    }

    // POST: Inscricao/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(InscricaoViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            // Salvar a inscrição em sessão para confirmação
            // HttpContext.Session.Set("InscricaoData", viewModel.Inscricao);
            return RedirectToAction(nameof(Confirmacao));
        }

        viewModel.Pacotes = new SelectList(_context.Pacotes.ToList(), "CodPacote", "Descricao");
        viewModel.Atividades = _context.Atividades.ToList();
        return View(viewModel);
    }

    // GET: Inscricao/Confirmacao
    public IActionResult Confirmacao()
    {
        // var inscricao = HttpContext.Session.Get<InscricaoModel>("InscricaoData");
        InscricaoModel inscricao = null;
        if (inscricao == null)
        {
            return RedirectToAction(nameof(Create));
        }

        var viewModel = new ConfirmacaoViewModel
        {
            Inscricao = inscricao,
            PacoteDescricao = _context.Pacotes.FirstOrDefault(p => p.CodPacote == inscricao.PacoteId)?.Descricao,
            AtividadesSelecionadas = _context.Atividades
                .Where(a => inscricao.AtividadesSelecionadas.Contains(a.CodAtv))
                .ToList()
        };

        return View(viewModel);
    }

    // POST: Inscricao/Confirmacao
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Confirmacao(ConfirmacaoViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);
        
        // Salvar a inscrição no banco de dados
        // _context.Inscricoes.Add(viewModel.Inscricao);
        _context.SaveChanges();

        // Limpar a sessão
        HttpContext.Session.Remove("InscricaoData");

        return RedirectToAction(nameof(Sucesso));                        
    }

    public IActionResult Sucesso()
    {
        return View();
    }

}