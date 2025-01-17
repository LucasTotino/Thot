using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Thot.Filters;
using Thot.Models;

namespace Thot.Controllers
{
    public class HomeController : Controller
    {
        [UsuarioLogado]
        public IActionResult Index()
        {
        
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}