using Microsoft.AspNetCore.Mvc;
using SistemaDeNotas.Filters;
using SistemaDeNotas.Models;
using SistemaDeNotas.Repositorio;

namespace SistemaDeNotas.Controllers
{
    [PaginaParaUsuarioLogado]
    public class NotaController : Controller
    {
        private readonly INotaRepositorio _notaRepositorio;
        public NotaController(INotaRepositorio notaRepositorio)
        {
            _notaRepositorio= notaRepositorio;
        }
        public IActionResult Index()
        {
            List<NotaModel> notas = _notaRepositorio.BuscarTodos();
            return View(notas);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            NotaModel nota =  _notaRepositorio.ListarPorId(id);
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
                    _notaRepositorio.Adicionar(nota);
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
                    _notaRepositorio.Atualizar(nota);
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
