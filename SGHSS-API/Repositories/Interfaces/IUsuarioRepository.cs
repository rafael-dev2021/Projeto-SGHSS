using SGHSS_API.Models;

namespace SGHSS_API.Repositories.Interfaces;

public interface IUsuarioRepository
{
    Usuario? ValidarUsuario(string email, string senha);
    IEnumerable<Usuario> ListarUsuarios();
}
