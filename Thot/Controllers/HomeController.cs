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
        
    }
}