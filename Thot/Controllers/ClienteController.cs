using Microsoft.AspNetCore.Mvc;
using Thot.Models;
using Thot.Repositorio;

namespace Thot.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public IActionResult Index(ClienteModel cliente)
        {
            return View();
        }

        public IActionResult ListaClientes()
        {
            List<ClienteModel> clientes = _clienteRepositorio.BuscarTodos();
            return View(clientes);
        }
        
        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ClienteModel cliente = _clienteRepositorio.ListarPorId(id);
            return View(cliente);
        }

        public IActionResult Apagar(int id)
        {
            _clienteRepositorio.Apagar(id);
            return RedirectToAction("ListaClientes");
        }

        [HttpPost]
        public IActionResult Criar(ClienteModel cliente)
        {
            if (ModelState.IsValid) 
            {
                _clienteRepositorio.Adicionar(cliente);
                return RedirectToAction("ListaClientes");
            }
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(ClienteModel cliente)
        {
            _clienteRepositorio.Atualizar(cliente);
            return RedirectToAction("ListaClientes");
        }
    }
}
