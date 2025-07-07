namespace SGHSS_API.Models;

public class Consulta
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime DataHora { get; set; }
    public string? Tipo { get; set; } 
    public string? Status { get; set; }
    public Guid PacienteId { get; set; }
    public Guid ProfissionalId { get; set; }
}
