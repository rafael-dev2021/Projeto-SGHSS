using SGHSS_API.Models;

namespace SGHSS_API.Repositories.Interfaces;

public interface IProfissionalRepository
{
    Task<IEnumerable<ProfissionalSaude>> GetAllAsync();
}
