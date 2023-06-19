using Microsoft.AspNetCore.Mvc;
using SistemaDeNotas.Enums;
using SistemaDeNotas.Filters;
using SistemaDeNotas.Helper;
using SistemaDeNotas.Models;
using SistemaDeNotas.Repositorio;

namespace SistemaDeNotas.Controllers
{
    [PaginaRestritaSomenteAdmin]
    public class AdminNotasController : Controller
    {
            private readonly INotaRepositorio _notaRepositorio;
            private readonly ISessao _sessao;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
            public AdminNotasController(INotaRepositorio notaRepositorio,
                                   ISessao sessao,
                                   IUsuarioRepositorio usuarioRepositorio)
            {
                _notaRepositorio = notaRepositorio;
                _sessao = sessao;
            _usuarioRepositorio = usuarioRepositorio;
            }
            public IActionResult Index()
            {
            List<NotaModel> notas = _notaRepositorio.BuscarTodosAdm();
            return View(notas);

        }
            public IActionResult Criar()
            {
               // UsuarioModel Usuario = _usuarioRepositorio.ListarPorId(id);
                return View();
            }
            public IActionResult Editar(int id)
            {
                NotaModel nota = _notaRepositorio.ListarPorId(id);
                return View(nota);
            }
            public IActionResult ApagarConfirmacao(int id)
            {
                NotaModel nota = _notaRepositorio.ListarPorId(id);
                return View(nota);
            }
            public IActionResult Apagar(int id)
            {
                try
                {
                    UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                    UsuarioModel usuario = new UsuarioModel();
                    usuario.Perfil = usuarioLogado.Perfil;
                    if (usuario.Perfil != PerfilEnum.Admin) throw new Exception(" Usuário não é admin");
                    bool apagado = _notaRepositorio.Apagar(id);
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
            public IActionResult Criar(NotaModel nota)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                    UsuarioModel Usuario = new UsuarioModel();
                    UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                     Usuario.Perfil = usuarioLogado.Perfil;
                    if (Usuario.Perfil != PerfilEnum.Admin) throw new Exception(" Usuário não é admin");
                    nota.UsuarioID = usuarioLogado.Id;
                   // nota.UsuarioID = Usuario.Id;
                    nota = _notaRepositorio.Adicionar(nota);
                        TempData["MensagemSucesso"] = "Inserido com sucesso";
                        return RedirectToAction("Index");
                    }
                    return View(nota);
                }
                catch (Exception erro)
                {
                    TempData["MensagemErro"] = $"Falha ao inserir, tente novamente, detalhes:{erro.Message} ";
                    return RedirectToAction("Index");
                }

            }
            [HttpPost]
            public IActionResult Alterar(NotaModel nota)
            {

                try
                {
                    if (ModelState.IsValid)
                    {
                    UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                    UsuarioModel usuario = new UsuarioModel();
                     usuario.Perfil = usuarioLogado.Perfil;
                    if (usuario.Perfil != PerfilEnum.Admin) throw new Exception(" Usuário não é admin");
                    nota = _notaRepositorio.Atualizar(nota);
                        TempData["MensagemSucesso"] = "Alterado com sucesso";
                        return RedirectToAction("Index");
                    }

                    return View("Editar", nota);
                }

                catch (Exception erro)
                {
                    TempData["MensagemErro"] = $"Falha ao Alterar, tente novamente, detalhes:{erro.Message} ";
                    return RedirectToAction("Index");
                }
            }
    }
}
