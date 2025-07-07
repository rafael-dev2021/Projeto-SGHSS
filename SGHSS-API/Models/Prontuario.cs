namespace SGHSS_API.Models; 

public class Prontuario
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid PacienteId { get; set; }
    public DateTime DataRegistro { get; set; }
    public string? Descricao { get; set; }
    public string? Prescricao { get; set; }
    public Guid ProfissionalId { get; set; }
}
