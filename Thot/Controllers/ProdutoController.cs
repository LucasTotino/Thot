using Microsoft.AspNetCore.Mvc;

namespace Thot.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Criar()
        {
            return View();
        }
    }
}
