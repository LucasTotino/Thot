using Microsoft.AspNetCore.Mvc;
using Thot.Filters;

namespace Thot.Controllers
{
    [UsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
