using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SucessoEventos.Entities;
using SucessoEventos.Web.Extensions;
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
    public async Task<IActionResult> Index()
    {
        var inscricoes = await _context.Participantes
            .Include(i => i.AxParticipanteAtividades) // Assuming you have a navigation property to Pacote
                .ThenInclude(at => at.Atividade)
            // .Include(i => i.Atividades) // Assuming you have a navigation property to Atividades
            .Include(i => i.AxParticipantePacotes)
                .ThenInclude(p => p.Pacote)
            .ToListAsync();
        var inscricoesReadModel = inscricoes.Select(ins => new ReadInscricaoModel {
            CodigoParticipante = ins.CodPar
            ,DataNascimento = ins.DataNascimento.ToShortDateString()
            ,Nome = ins.Nome
            ,Telefone = ins.Telefone
            ,Pacote = ins.AxParticipantePacotes.Select(p => p.Pacote).FirstOrDefault() ?? default!
            ,Atividades = ins.AxParticipanteAtividades.Select(p => p.Atividade).ToList()            
        });
        return View(inscricoesReadModel);
    }
    // GET: Inscricao/Create
    public IActionResult Create()
    {
        var viewModel = new InscricaoViewModel
        {
            Inscricao = new InscricaoModel(),
            Pacotes = new SelectList(_context.Pacotes.ToList(), "CodPacote", "Descricao"),
            Atividades = _context.Atividades.Select(atv => new SelectListItem(atv.DescAtv,atv.CodAtv.ToString())).ToList()
        };

        return View(viewModel);
    }

    // POST: Inscricao/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(InscricaoViewModel viewModel)
    {
        ModelState.Remove("Pacotes");
        if (ModelState.IsValid)
        {
            // Salvar a inscrição em sessão para confirmação
            HttpContext.Session.Set("InscricaoData",viewModel.Inscricao);
            return RedirectToAction(nameof(Confirmacao));
        }

        viewModel.Pacotes = new SelectList(_context.Pacotes.ToList(), "CodPacote", "Descricao");
        viewModel.Atividades = _context.Atividades.Select(atv => new SelectListItem(atv.DescAtv,atv.CodAtv.ToString())).ToList();
        return View(viewModel);
    }

    // GET: Inscricao/Confirmacao
    public IActionResult Confirmacao()
    {
        InscricaoModel? inscricao = HttpContext.Session.Get<InscricaoModel>("InscricaoData");
        if (inscricao == null)
        {
            return RedirectToAction(nameof(Create));
        }

        var viewModel = new ConfirmacaoViewModel
        {
            Inscricao = inscricao,
            PacoteDescricao = _context.Pacotes.FirstOrDefault(p => p.CodPacote == inscricao.PacoteId)?.Descricao ?? "Não encontrado",
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
        InscricaoModel? inscricao = HttpContext.Session.Get<InscricaoModel>("InscricaoData");
        if (inscricao is null)
            return RedirectToAction(nameof(Create));
        
        // Salvar a inscrição no banco de dados
        var participante = new Participante(){
            Nome = inscricao.Nome
            ,DataNascimento = DateTime.ParseExact(inscricao.DataNascimento,"dd/MM/yyyy",null)
            ,Telefone = inscricao.Telefone
            // ,AxParticipantePacotes = new AxParticipantePacote[]{
            //     new AxParticipantePacote{
            //         Participante = this
            //     }
            // }
        };
        
        _context.Participantes.Add(participante);
        _context.SaveChanges();
        var participantePacote = new AxParticipantePacote(){
            CodPacote = inscricao.PacoteId
            ,CodPar = participante.CodPar
        };
        var participanteAtividades = inscricao.AtividadesSelecionadas.Select(atv => new AxParticipanteAtividade{
            CodAtv = atv            
            ,CodPar = participante.CodPar
        });
        _context.AxParticipanteAtividade.AddRange(participanteAtividades);
        _context.AxParticipantePacote.Add(participantePacote);
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