using SGHSS_API.Models;

namespace SGHSS_API.Repositories.Interfaces;

public interface IProntuarioRepository
{
    Task<IEnumerable<Prontuario>> GetAllAsync();
    Task<Prontuario?> GetByIdAsync(Guid id); 
}
