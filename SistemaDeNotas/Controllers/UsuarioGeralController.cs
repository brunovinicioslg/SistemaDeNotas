using Microsoft.AspNetCore.Mvc;
using SistemaDeNotas.Filters;
using SistemaDeNotas.Helper;
using SistemaDeNotas.Models;
using SistemaDeNotas.Repositorio;

namespace SistemaDeNotas.Controllers
{
    public class UsuarioGeralController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly INotaRepositorio _notaRepositorio;
        private readonly IEmail _email;
        public UsuarioGeralController(IUsuarioRepositorio usuarioRepositorio,
                                 INotaRepositorio notaRepositorio,
                                 IEmail email)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _notaRepositorio = notaRepositorio;
            _email = email;
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
                    if (usuarios != null)
                    {

                        string mensagem = $"Novo usuario criado: {usuarios.Nome}";
                        string emailreceber = "brunovinicios775@gmail.com";
                        bool emailEnviado = _email.Enviar(emailreceber, "Novo Usuario Criado - Sistema de Notas", mensagem);

                    }
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
