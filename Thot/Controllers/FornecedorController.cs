using Microsoft.AspNetCore.Mvc;
using Thot.Models;
using Thot.Repositorio;

namespace Thot.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly FornecedorRepositorio _fornecedorRepositorio;
        public FornecedorController(FornecedorRepositorio fornecedorRepositorio)
        {
            _fornecedorRepositorio = fornecedorRepositorio;
        }
        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult ListaFornecedores()
        {
            List<FornecedorModel> fornecedores = _fornecedorRepositorio.BuscarTodos();
            return View(fornecedores);
        }
    }
}
