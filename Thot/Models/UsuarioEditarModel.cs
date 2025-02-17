﻿using System;
using System.ComponentModel.DataAnnotations;
using Thot.Enum;

namespace Thot.Models
{
    public class UsuarioEditarModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o Nome do Usuário")]
        public string Nome { get; set; }
        [EmailAddress(ErrorMessage = "O Email informado é invalido")]
        [Required(ErrorMessage = "Digite o Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o Login do Usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o CPF do Usuário")]
        public string Cpf { get; set; }
        public PerfilEnum Perfil { get; set; }
    }
}
