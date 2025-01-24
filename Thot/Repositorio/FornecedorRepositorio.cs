using Thot.Data;
using Thot.Models;

namespace Thot.Repositorio
{
    public class FornecedorRepositorio : IFornecedorRepositorio
    {
        private readonly BancoContext _bancoContext;
        public FornecedorRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public FornecedorModel ListarPorId(int id)
        {
            return _bancoContext.Fornecedores.FirstOrDefault(x => x.Id == id);
        }

        public List<FornecedorModel> BuscarTodos()
        {
            return _bancoContext.Fornecedores.ToList();
        }

        public FornecedorModel Adicionar(FornecedorModel fornecedor)
        {
            // Inserção no Banco de Dados
            _bancoContext.Fornecedores.Add(fornecedor);
            _bancoContext.SaveChanges();

            return fornecedor;
        }

        public FornecedorModel Atualizar(FornecedorModel fornecedor)
        {
            FornecedorModel fornecedorDB = ListarPorId(fornecedor.Id);

            if (fornecedorDB == null) throw new System.Exception("Houve um erro na Atualização do Cliente");

            fornecedorDB.Nome = fornecedor.Nome;
            fornecedorDB.Email = fornecedor.Email;
            fornecedorDB.Contato = fornecedor.Contato;
            fornecedorDB.Cpf_Cnpj = fornecedor.Cpf_Cnpj;
            fornecedorDB.TipoFornecedor = fornecedor.TipoFornecedor;
            fornecedorDB.Cep = fornecedor.Cep;
            fornecedorDB.Logradouro = fornecedor.Logradouro;
            fornecedorDB.Numero = fornecedor.Numero;
            fornecedorDB.Complemento = fornecedor.Complemento;
            fornecedorDB.Cidade = fornecedor.Cidade;
            fornecedorDB.Estado = fornecedor.Estado;
            fornecedorDB.Bairro = fornecedor.Bairro;

            _bancoContext.Fornecedores.Update(fornecedorDB);
            _bancoContext.SaveChanges();

            return fornecedorDB;
        }

        public bool Apagar(int id)
        {
            FornecedorModel fornecedorDB = ListarPorId(id);

            if (fornecedorDB == null) throw new System.Exception("Houve um erro na Deleção do Fornecedor");

            _bancoContext.Fornecedores.Remove(fornecedorDB);
            _bancoContext.SaveChanges();
            return true;
        }

    }
}
