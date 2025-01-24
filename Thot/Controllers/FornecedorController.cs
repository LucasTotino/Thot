using Microsoft.AspNetCore.Mvc;
using Thot.Models;

namespace Thot.Controllers
{
    public class FornecedorController : Controller
    {
        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult ListaFornecedores()
        {
            List<ClienteModel> fornecedores = _fornecedorRepositorio.BuscarTodos();
            return View(fornecedores);
        }
    }
}
