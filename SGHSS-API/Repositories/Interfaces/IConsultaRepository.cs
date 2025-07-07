using SGHSS_API.Models;

namespace SGHSS_API.Repositories.Interfaces;

public interface IConsultaRepository
{
    Task<IEnumerable<Consulta>> GetAllAsync();
    Task CreateAsync(Consulta consulta);
}
