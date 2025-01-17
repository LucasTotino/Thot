using Thot.Models;

namespace Thot.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarPorEmail(string email);
        UsuarioModel BuscarPorLogin(string login);
        UsuarioModel ListarPorId(int id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
        bool Apagar(int id);
    }
}
