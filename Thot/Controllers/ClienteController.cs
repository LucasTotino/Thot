using Microsoft.AspNetCore.Mvc;
using Thot.Filters;
using Thot.Models;
using Thot.Repositorio;

namespace Thot.Controllers
{
    [UsuarioLogado]
    public class ClienteController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
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
            try
            {
                bool apagado = _clienteRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Cliente apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Erro ao apagar o cliente";
                }
                return RedirectToAction("ListaClientes");
            }
            catch (System.Exception erro) {
                TempData["MensagemErro"] = $"Erro ao apagar o cliente, detalhe do erro: {erro.Message}";
                return RedirectToAction("ListaClientes");
            }
        }

        [HttpPost]
        public IActionResult Criar(ClienteModel cliente)
        {
            try { 
            if (ModelState.IsValid) 
            {
                _clienteRepositorio.Adicionar(cliente);
                TempData["MensagemSucesso"] = "Cliente cadastrado com suceso";
                return RedirectToAction("ListaClientes");
            }
            
            return View(cliente);

            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao cadastrar o cliente, detalhe do erro: {erro.Message}";
                return RedirectToAction("ListaClientes");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ClienteModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteRepositorio.Atualizar(cliente);
                    TempData["MensagemSucesso"] = "Cliente alterado com suceso";
                    return RedirectToAction("ListaClientes");
                }

                return View("Editar", cliente);

            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao alterar o cliente, detalhe do erro: {erro.Message}";
                return RedirectToAction("ListaClientes");
            }

            
        }
        
    }
}
