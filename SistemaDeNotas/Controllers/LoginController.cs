using Microsoft.AspNetCore.Mvc;
using SistemaDeNotas.Helper;
using SistemaDeNotas.Models;
using SistemaDeNotas.Repositorio;

namespace SistemaDeNotas.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        private readonly IEmail _email;
        public LoginController(IUsuarioRepositorio usuarioRepositorio,
                                ISessao sessao,
                                IEmail email)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
            _email = email;
        }
        public IActionResult Index()
        {
            //se o usuario estiver logado redirecionar p Home
            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult RedefinirSenha()
        {
            return View();
        }

        public IActionResult Sair()
        {

            _sessao.RemoverSessaoDousuario();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorlogin(loginModel.Usuario);
                    if(usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoDousuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = "Senha Inválida";
                    }
                    TempData["MensagemErro"] = $"Usuario ou senha inválidos";
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Falha ao Entrar, tente novamente, detalhes:{erro.Message} ";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult EnviarLinkParaRedefinirSenha(RedefinirSenhaModel redefinirSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorEmailELogin(redefinirSenhaModel.Email, redefinirSenhaModel.Usuario);
                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        
                        string mensagem = $"Sua nova senha é: {novaSenha}";
                        bool emailEnviado = _email.Enviar(usuario.Email, "Sistema de Notas - Nova Senha", mensagem);

                        if (emailEnviado)
                        {
                            _usuarioRepositorio.AtualizarSenha(usuario);
                            TempData["MensagemSucesso"] = $"Enviamos para seu email cadastrado a nova senha.";
                        }
                        else
                        {
                            TempData["MensagemErro"] = $"Não conseguimos enviar o email, tente novamente";
                        }
                        return RedirectToAction("Index", "Login");
                    }
                    TempData["MensagemErro"] = $"Não conseguimos redefinir sua senha, verifique os dados.";
                }
                return View("RedefinirSenha", redefinirSenhaModel);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos redefinir sua senha, detalhes:{erro.Message} ";
                return RedirectToAction("Index", redefinirSenhaModel);
            }
        }
    }
}
