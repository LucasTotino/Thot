using System.ComponentModel.DataAnnotations;

namespace Thot.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o Nome do Cliente")]
        public string Nome { get; set; }
        [EmailAddress(ErrorMessage = "O Email informado é invalido")]
        [Required(ErrorMessage = "Digite o Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o Telefone para contato")]
        [Phone(ErrorMessage = "O Telefone informado é invalido")]
        public string Celular { get; set; }
        [Required(ErrorMessage = "Digite o CPF/CNPJ do Cliente")]
        public string Cpf_Cnpj { get; set; }
        public string TipoCliente { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Bairro{ get; set; }

    }
}
