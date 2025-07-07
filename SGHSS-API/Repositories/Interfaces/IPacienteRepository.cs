using SGHSS_API.Models;

namespace SGHSS_API.Repositories.Interfaces;

public interface IPacienteRepository
{
    Task<IEnumerable<Paciente>> GetAllAsync();
    Task<Paciente?> GetByIdAsync(Guid id);
    Task CreateAsync(Paciente paciente);
}
