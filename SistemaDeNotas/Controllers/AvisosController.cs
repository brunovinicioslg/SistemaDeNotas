using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SistemaDeNotas.Enums;
using SistemaDeNotas.Filters;
using SistemaDeNotas.Helper;
using SistemaDeNotas.Models;
using SistemaDeNotas.Repositorio;

namespace SistemaDeNotas.Controllers
{
    [PaginaRestritaSomenteAdmin]
    [EnableCors]
    public class AvisosController : Controller
    {
        private readonly ISessao _sessao;
        private readonly IAvisosRepositorio _avisosRepositorio;

        public AvisosController(IAvisosRepositorio avisosRepositorio,
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
        public IActionResult Criar()
        {

            return View();
        }
        public IActionResult Editar(int id)
        {
            AvisosModel aviso = _avisosRepositorio.ListarPorId(id);
            return View(aviso);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            AvisosModel aviso = _avisosRepositorio.ListarPorId(id);
            return View(aviso);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                UsuarioModel usuario = new UsuarioModel();
                usuario.Perfil = usuarioLogado.Perfil;
                if (usuario.Perfil != PerfilEnum.Admin) throw new Exception(" Usuário não é admin");
                bool apagado = _avisosRepositorio.Apagar(id);
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
        public IActionResult ListarAvisos()
        {
            List<AvisosModel> avisos = _avisosRepositorio.BuscarTodosAdm();
            return PartialView("_Avisos", avisos);
        }

        [HttpPost]
        public IActionResult Criar(AvisosModel aviso)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    AvisosModel aviso2 = null;
                    aviso2 = new AvisosModel()
                    {
                        AvisoCorpo = aviso.AvisoCorpo,
                        AvisoTitulo = aviso.AvisoTitulo

                    };


                    UsuarioModel UsuarioN = new UsuarioModel();
                    UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                    UsuarioN.Perfil = usuarioLogado.Perfil;
                    if (UsuarioN.Perfil != PerfilEnum.Admin) throw new Exception(" Usuário não é admin");
                    aviso2 = _avisosRepositorio.Adicionar(aviso2);
                    TempData["MensagemSucesso"] = "Inserido com sucesso";
                    return RedirectToAction("Index");
                }
                return View(aviso);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Falha ao inserir, tente novamente, detalhes:{erro.Message} ";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Alterar(AvisosModel aviso)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                    UsuarioModel usuario = new UsuarioModel();
                    usuario.Perfil = usuarioLogado.Perfil;
                    if (usuario.Perfil != PerfilEnum.Admin) throw new Exception(" Usuário não é admin");
                    aviso = _avisosRepositorio.Atualizar(aviso);
                    TempData["MensagemSucesso"] = "Alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View("Editar", aviso);
            }

            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Falha ao Alterar, tente novamente, detalhes:{erro.Message} ";
                return RedirectToAction("Index");
            }
        }
    }
}
