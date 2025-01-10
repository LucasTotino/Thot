using Thot.Data;
using Thot.Models;

namespace Thot.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ClienteRepositorio(BancoContext bancoContext) 
        {
            _bancoContext = bancoContext;
        }
        public ClienteModel ListarPorId(int id)
        {
            return _bancoContext.Clientes.FirstOrDefault(x => x.Id == id);
        }

        public List<ClienteModel> BuscarTodos()
        {
            return _bancoContext.Clientes.ToList();
        }

        public ClienteModel Adicionar(ClienteModel cliente)
        {
            // Inserção no Banco de Dados
            _bancoContext.Clientes.Add(cliente);
            _bancoContext.SaveChanges();

            return cliente;
        }

        public ClienteModel Atualizar(ClienteModel cliente)
        {
            ClienteModel clienteDB = ListarPorId(cliente.Id);

            if (clienteDB == null) throw new System.Exception("Houve um erro na Atualização do Cliente");

            clienteDB.Nome = cliente.Nome;
            clienteDB.Email = cliente.Email;
            clienteDB.Celular = cliente.Celular;
            clienteDB.Cpf_Cnpj = cliente.Cpf_Cnpj;
            clienteDB.TipoCliente = cliente.TipoCliente;
            clienteDB.Cep = cliente.Cep;
            clienteDB.Logradouro = cliente.Logradouro;
            clienteDB.Numero = cliente.Numero;
            clienteDB.Complemento = cliente.Complemento;
            clienteDB.Cidade = cliente.Cidade;
            clienteDB.Estado = cliente.Estado;
            clienteDB.Bairro = cliente.Bairro;  

            _bancoContext.Clientes.Update(clienteDB);
            _bancoContext.SaveChanges();

            return clienteDB;
        }

        public bool Apagar(int id)
        {
            ClienteModel clienteDB = ListarPorId(id);

            if (clienteDB == null) throw new System.Exception("Houve um erro na Deleção do Cliente");

            _bancoContext.Clientes.Remove(clienteDB);
            _bancoContext.SaveChanges();
            return true;
        }

    }
}
