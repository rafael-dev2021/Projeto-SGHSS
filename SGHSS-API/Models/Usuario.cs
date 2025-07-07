namespace SGHSS_API.Models;

public class Usuario
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Email { get; set; }
    public string? Senha { get; set; }
    public string? Perfil { get; set; }
}
