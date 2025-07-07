using Microsoft.EntityFrameworkCore;
using SGHSS_API.Context;
using SGHSS_API.Models;
using SGHSS_API.Repositories.Interfaces;

namespace SGHSS_API.Repositories;

public class ProfissionalRepository(SghssDbContext context) : IProfissionalRepository
{
    private readonly SghssDbContext _context = context;

    public async Task<IEnumerable<ProfissionalSaude>> GetAllAsync() => await _context.Profissionais.ToListAsync();
}
