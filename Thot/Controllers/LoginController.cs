using Microsoft.AspNetCore.Mvc;

namespace Thot.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
