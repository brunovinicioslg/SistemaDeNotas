using Microsoft.AspNetCore.Mvc;
using SistemaDeNotas.Enums;
using SistemaDeNotas.Filters;
using SistemaDeNotas.Helper;
using SistemaDeNotas.Models;
using SistemaDeNotas.Repositorio;
using System;

namespace SistemaDeNotas.Controllers
{
    
    public class AdminNotasController : Controller
    {
            private readonly INotaRepositorio _notaRepositorio;
            private readonly ISessao _sessao;
            private readonly IUsuarioRepositorio _usuarioRepositorio;
            private readonly IEmail _email;
        public AdminNotasController(INotaRepositorio notaRepositorio,
                                   ISessao sessao,
                                   IUsuarioRepositorio usuarioRepositorio,
                                   IEmail email)
            {
                _notaRepositorio = notaRepositorio;
                _sessao = sessao;
                 _usuarioRepositorio = usuarioRepositorio;
                _email = email;
             }
             [PaginaRestritaSomenteAdmin]
            public IActionResult Index()
            {

            List<NotaModel> notas = _notaRepositorio.BuscarTodosAdm();
            return View(notas);

             }
             [PaginaRestritaSomenteAdmin]
            public IActionResult Criar()
            {

            return View();
            }
             [PaginaRestritaSomenteAdmin]
             public IActionResult Editar(int id)
            {
                NotaModel nota = _notaRepositorio.ListarPorId(id);
                return View(nota);
            }
                [PaginaRestritaSomenteAdmin]
              public IActionResult ApagarConfirmacao(int id)
            {
                NotaModel nota = _notaRepositorio.ListarPorId(id);
                return View(nota);
            }
                [PaginaRestritaSomenteAdmin]
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
             [PaginaRestritaSomenteAdmin]
             public IActionResult Criar(NotaModel nota)
            {
                try
                {
                    if (ModelState.IsValid)
                    {

                    NotaModel nota2 = null;
                    nota2 = new NotaModel()
                    {
                        UsuarioID = nota.UsuarioID,
                        Materia = nota.Materia,
                        Nota1Bimestre = nota.Nota1Bimestre,
                        Nota2Bimestre = nota.Nota2Bimestre,
                        Nota3Bimestre = nota.Nota3Bimestre,
                        Nota4bimestre = nota.Nota4bimestre,
                        UsuarioNome= nota.UsuarioNome,
                        UsuarioTurma = nota.UsuarioTurma,
                        UsuarioEmail = nota.UsuarioEmail

                    };


                    UsuarioModel UsuarioN = new UsuarioModel();
                    UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                    UsuarioModel nome = _usuarioRepositorio.BuscarNome(nota2.UsuarioID);
                    nota2.UsuarioNome = nome.Nome;
                    nota2.UsuarioTurma= nome.Turma;
                    nota2.UsuarioEmail= nome.Email;
                    string emailenviar = nota2.UsuarioEmail;
                    UsuarioN.Perfil = usuarioLogado.Perfil;

                    if (usuarioLogado != null)
                    {
                        string mensagem = $"Nova nota adicionada para seu Usuario, acesse o sistema e confira! https://sistemadenotas.azurewebsites.net/ ";
                        bool emailEnviado = _email.Enviar(emailenviar, "Nova Nota Cadastrada - E. E. Santa Terezinha", mensagem);

                    }
                    if (UsuarioN.Perfil != PerfilEnum.Admin) throw new Exception(" Usuário não é admin");
                    nota2 = _notaRepositorio.Adicionar(nota2);
                        TempData["MensagemSucesso"] = "Inserido com sucesso";
                        return RedirectToAction("Index", "Usuario");
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
                [PaginaRestritaSomenteAdmin]
             public IActionResult Alterar(NotaModel nota)
            {

                try
                {
                    if (ModelState.IsValid)
                    {

                   
                    UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                    UsuarioModel usuario = new UsuarioModel();
                    UsuarioModel nome = _usuarioRepositorio.BuscarNome(nota.UsuarioID);

                    string mensagem = $"Nova nota adicionada para seu Usuario, acesse o sistema e confira! https://sistemadenotas.azurewebsites.net/ ";
                    bool emailEnviado = _email.Enviar(nota.UsuarioEmail, "Nova Nota Cadastrada - E. E. Santa Terezinha", mensagem);



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
