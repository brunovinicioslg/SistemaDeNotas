using Microsoft.AspNetCore.Mvc;
using SistemaDeNotas.Enums;
using SistemaDeNotas.Filters;
using SistemaDeNotas.Helper;
using SistemaDeNotas.Models;
using SistemaDeNotas.Repositorio;

namespace SistemaDeNotas.Controllers
{
    [PaginaParaUsuarioLogado]
    public class ExibirAvisoController : Controller
    {
       
        private readonly ISessao _sessao;
        private readonly IAvisosRepositorio _avisosRepositorio;

        public ExibirAvisoController(IAvisosRepositorio avisosRepositorio,
                                ISessao sessao)
        {
            _sessao = sessao;
            _avisosRepositorio = avisosRepositorio;
        }
        public IActionResult Index()
        {
            List<AvisosModel> avisos = _avisosRepositorio.BuscarTodosAdm();
            return View(avisos);
        }
        
        public IActionResult ListarAvisos()
        {
            List<AvisosModel> avisos = _avisosRepositorio.BuscarTodosAdm();
            return PartialView("_Avisos", avisos);
        }
    }
}
