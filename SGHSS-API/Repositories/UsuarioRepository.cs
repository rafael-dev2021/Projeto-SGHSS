using SGHSS_API.Context;
using SGHSS_API.Models;
using SGHSS_API.Repositories.Interfaces;

namespace SGHSS_API.Repositories;

public class UsuarioRepository(SghssDbContext context) : IUsuarioRepository
{
    private readonly SghssDbContext _context = context;

    public Usuario? ValidarUsuario(string email, string senha) =>
        _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);

    public IEnumerable<Usuario> ListarUsuarios() => _context.Usuarios.ToList();
}
