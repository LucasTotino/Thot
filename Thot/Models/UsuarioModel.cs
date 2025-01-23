using System;
using System.ComponentModel.DataAnnotations;
using Thot.Enum;
using Thot.Helper;

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
        [Required(ErrorMessage = "Digite o Login do Usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o CPF do Usuário")]
        public string Cpf { get; set; }
        public PerfilEnum Perfil { get; set; }
        [Required(ErrorMessage = "Digite a Senha")]
        public string Senha { get; set; }
        public DateTime Data_Cadastro { get; set; }
        public DateTime? Data_Atualizacao { get; set; }
        public bool SenhaValida(string senha)
        {
            return Senha == senha.Criptografar();
        }
        public void SenhaHash()
        {
            Senha = Senha.Criptografar();
        }
        public string NovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0,8);
            Senha = novaSenha.Criptografar();
            return novaSenha;
        }
    }
}
