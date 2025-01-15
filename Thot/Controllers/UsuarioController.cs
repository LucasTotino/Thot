﻿using Microsoft.AspNetCore.Mvc;
using Thot.Models;
using Thot.Repositorio;

namespace Thot.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio) 
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult ListaUsuarios()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }
        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuario apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Erro ao apagar o Usuario";
                }
                return RedirectToAction("ListaUsuarios");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao apagar o usuário, detalhe do erro: {erro.Message}";
                return RedirectToAction("ListaUsuarios");
            }
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario cadastrado com suceso";
                    return RedirectToAction("ListaUsuarios");
                }

                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage); // Ou use um logger
                }

                return View(usuario);

            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao cadastrar o usuario, detalhe do erro: {erro.Message}";
                return RedirectToAction("ListaUsuarios");
            }
        }

        [HttpPost]
        public IActionResult Alterar(UsuarioEditarModel usuarioEditar)
        {
            try
            {
                UsuarioModel usuario = null;
                if (ModelState.IsValid)
                {
                   usuario = new UsuarioModel()
                    {
                        Id = usuarioEditar.Id,
                        Nome = usuarioEditar.Nome,
                        Email = usuarioEditar.Email,
                        Cpf = usuarioEditar.Cpf,
                        Login = usuarioEditar.Login,
                        Perfil = usuarioEditar.Perfil,
                    };
                    usuario = _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuario alterado com suceso";
                    return RedirectToAction("ListaUsuarios");
                }

                return View("Editar", usuario);

            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao alterar o usuario, detalhe do erro: {erro.Message}";
                return RedirectToAction("ListaUsuarios");
            }


        }
    }
}
