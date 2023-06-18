using Microsoft.AspNetCore.Mvc;
using SistemaDeNotas.Filters;

namespace SistemaDeNotas.Controllers
{
    [PaginaParaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
