using System.ComponentModel.DataAnnotations;

namespace SGHSS_API.Models;

public class Paciente
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required] public string? Nome { get; set; }
    public string? CPF { get; set; }
    public DateTime DataNascimento { get; set; }
    public string? Convenio { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
}
