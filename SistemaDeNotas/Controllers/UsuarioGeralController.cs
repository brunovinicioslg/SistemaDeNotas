using Microsoft.AspNetCore.Mvc;
using SistemaDeNotas.Filters;
using SistemaDeNotas.Models;
using SistemaDeNotas.Repositorio;

namespace SistemaDeNotas.Controllers
{
    public class UsuarioGeralController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly INotaRepositorio _notaRepositorio;
        public UsuarioGeralController(IUsuarioRepositorio usuarioRepositorio,
                                 INotaRepositorio notaRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _notaRepositorio = notaRepositorio;
        }
        public IActionResult Index()
        {
   
            return RedirectToAction("Criar", "UsuarioGeral");
        }
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuarios)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuarios = _usuarioRepositorio.AdicionarGeral(usuarios);
                    TempData["MensagemSucesso"] = "Inserido com sucesso";
                    return RedirectToAction("Index", "Login");
                }
                return View(usuarios);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Falha ao inserir, tente novamente, detalhes:{erro.Message} ";
                return RedirectToAction("Criar", "UsuarioGeral");
            }

        }
    }
}
