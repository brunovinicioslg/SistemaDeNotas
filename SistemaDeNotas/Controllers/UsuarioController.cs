using Microsoft.AspNetCore.Mvc;
using SistemaDeNotas.Filters;
using SistemaDeNotas.Models;
using SistemaDeNotas.Repositorio;

namespace SistemaDeNotas.Controllers
{
    [PaginaRestritaSomenteAdmin]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Falha ao apagar";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Falha ao apagar, tente novamente, detalhes:{erro.Message} ";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Criar(UsuarioModel usuarios)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuarios = _usuarioRepositorio.Adicionar(usuarios);
                    TempData["MensagemSucesso"] = "Inserido com sucesso";
                    Console.WriteLine("teste");
                    return RedirectToAction("Index");
                }
                return View(usuarios);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Falha ao inserir, tente novamente, detalhes:{erro.Message} ";
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public IActionResult Editar(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {

            try
            {
                UsuarioModel usuario = null;
                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenhaModel.Id,
                        Nome = usuarioSemSenhaModel.Nome,
                        Usuario = usuarioSemSenhaModel.Usuario,
                        Email = usuarioSemSenhaModel.Email,
                        Turma = usuarioSemSenhaModel.Turma,
                        Perfil = usuarioSemSenhaModel.Perfil
                        
                    };
                   usuario = _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View("Editar", usuario);
            }

            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Falha ao Alterar, tente novamente, detalhes:{erro.Message} ";
                return RedirectToAction("Index");
            }
        }
    }
}
