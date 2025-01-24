using Thot.Enum;

namespace Thot.Models
{
    public class FornecedorModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? RazaoSocial{ get; set; }
        public TipoPessoa TipoFornecedor { get; set; }
        public string Cpf_Cnpj { get; set; }
        public string Contato { get; set; }
        public string? Email { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
