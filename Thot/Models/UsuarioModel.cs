﻿using System;
using System.ComponentModel.DataAnnotations;
using Thot.Enum;

namespace Thot.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o Nome do Usuário")]
        public string Nome { get; set; }
        [EmailAddress(ErrorMessage = "O Email informado é invalido")]
        [Required(ErrorMessage = "Digite o Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o CPF do Usuário")]
        public string Login { get; set; }
        public string Cpf { get; set; }
        public PerfilEnum Perfil { get; set; }
        public string Senha { get; set; }
        public DateTime Data_Cadastro { get; set; }
        public DateTime? Data_Atualizacao {  get; set; }
    }
}
