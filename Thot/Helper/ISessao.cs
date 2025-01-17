using Thot.Models;

namespace Thot.Helper
{
    public interface ISessao
    {
        void CriarSessaoUsuario(UsuarioModel usuario);
        void RemoveSessaoUsuario();
        UsuarioModel BuscarSessaoUsuario();
    }
}
