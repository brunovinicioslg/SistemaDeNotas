using Microsoft.AspNetCore.Mvc;
using SistemaDeNotas.Filters;
using SistemaDeNotas.Models;
using System.Diagnostics;

namespace SistemaDeNotas.Controllers
{
    [PaginaParaUsuarioLogado]
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}