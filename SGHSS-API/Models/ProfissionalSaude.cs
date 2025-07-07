namespace SGHSS_API.Models;

public class ProfissionalSaude
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Nome { get; set; }
    public string? Especialidade { get; set; }
    public string? CRM { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
}
