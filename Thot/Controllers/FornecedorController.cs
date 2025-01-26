using Microsoft.AspNetCore.Mvc;
using Thot.Filters;
using Thot.Models;
using Thot.Repositorio;

namespace Thot.Controllers
{
    [UsuarioLogado]
    public class FornecedorController : Controller
    {
        private readonly IFornecedorRepositorio _fornecedorRepositorio;
        public FornecedorController(IFornecedorRepositorio fornecedorRepositorio)
        {
            _fornecedorRepositorio = fornecedorRepositorio;
        }
        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult ListaFornecedores()
        {
            List<FornecedorModel> fornecedor = _fornecedorRepositorio.BuscarTodos();
            return View(fornecedor);
        }

        public IActionResult Editar(int id)
        {
            FornecedorModel fornecedor = _fornecedorRepositorio.ListarPorId(id);
            return View(fornecedor);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _fornecedorRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Fornecedor apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Erro ao apagar o fornecedor";
                }
                return RedirectToAction("ListaFornecedores");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao apagar o fornecedor, detalhe do erro: {erro.Message}";
                return RedirectToAction("ListaFornecedores");
            }
        }

        [HttpPost]
        public IActionResult Criar(FornecedorModel fornecedor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _fornecedorRepositorio.Adicionar(fornecedor);
                    TempData["MensagemSucesso"] = "Fornecedor cadastrado com suceso";
                    return RedirectToAction("ListaFornecedores");
                }

                return View(fornecedor);

            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao cadastrar o fornecedor, detalhe do erro: {erro.Message}";
                return RedirectToAction("ListaFornecedores");
            }
        }

        [HttpPost]
        public IActionResult Alterar(FornecedorModel fornecedor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _fornecedorRepositorio.Atualizar(fornecedor);
                    TempData["MensagemSucesso"] = "Fornecedor alterado com suceso";
                    return RedirectToAction("ListaFornecedores");
                }

                return View("Editar", fornecedor);

            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao alterar o fornecedor, detalhe do erro: {erro.Message}";
                return RedirectToAction("ListaFornecedor");
            }


        }
    }
}
