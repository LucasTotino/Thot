using Microsoft.AspNetCore.Mvc;
using Thot.Helper;
using Thot.Models;
using Thot.Repositorio;

namespace Thot.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public LoginController(IUsuarioRepositorio usuarioRepositorio,
            ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            //Se logado, redireciona para a Home
            if (_sessao.BuscarSessaoUsuario() != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoveSessaoUsuario();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = null;

                    if (loginModel.Login.Contains("@")) 
                    {
                         usuario = _usuarioRepositorio.BuscarPorEmail(loginModel.Login);
                    }
                    else 
                    { 
                        usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);
                    }

                    if (usuario != null) 
                    {
                        if(usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoUsuario(usuario);
                            return RedirectToAction("Index", "Home"); 
                        }
                        TempData["MensagemErro"] = $"Senha inválida. Por favor, tente novamente.";
                    }
                    else { 
                    TempData["MensagemErro"] = $"Login/E-mail errado. Por favor, tente novamente.";
                    }
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível realizar o Login, detalhe do erro: {erro.Message}";
                return RedirectToAction("ListaClientes");
            }
        }
    }
}
