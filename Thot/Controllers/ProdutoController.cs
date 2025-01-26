using Microsoft.AspNetCore.Mvc;
using Thot.Models;
using Thot.Repositorio;

namespace Thot.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }
        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult ListaProdutos()
        {
            List<ProdutoModel> produtos = _produtoRepositorio.BuscarTodos();
            return View(produtos);
        }
       
        public IActionResult Editar(int id)
        {
            ProdutoModel produto = _produtoRepositorio.ListarPorId(id);
            return View(produto);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _produtoRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Produto apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Erro ao apagar o produto";
                }
                return RedirectToAction("ListaProdutos");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao apagar o produto, detalhe do erro: {erro.Message}";
                return RedirectToAction("ListaProdutos");
            }
        }

        [HttpPost]
        public IActionResult Criar(ProdutoModel produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _produtoRepositorio.Adicionar(produto);
                    TempData["MensagemSucesso"] = "Produto cadastrado com suceso";
                    return RedirectToAction("ListaProdutos");
                }

                return View(produto);

            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao cadastrar o produto, detalhe do erro: {erro.Message}";
                return RedirectToAction("ListaProdutos");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ProdutoModel produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _produtoRepositorio.Atualizar(produto);
                    TempData["MensagemSucesso"] = "Produto alterado com suceso";
                    return RedirectToAction("ListaProdutos");
                }

                return View("Editar", produto);

            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao alterar o produto, detalhe do erro: {erro.Message}";
                return RedirectToAction("ListaProdutos");
            }


        }

    }
}
