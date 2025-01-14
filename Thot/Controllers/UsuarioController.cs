using Microsoft.AspNetCore.Mvc;

namespace Thot.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }
    }
}
