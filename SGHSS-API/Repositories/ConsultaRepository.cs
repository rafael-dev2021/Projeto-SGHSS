using Microsoft.EntityFrameworkCore;
using SGHSS_API.Context;
using SGHSS_API.Models;
using SGHSS_API.Repositories.Interfaces;

namespace SGHSS_API.Repositories;

public class ConsultaRepository(SghssDbContext context) : IConsultaRepository
{
    private readonly SghssDbContext _context = context;

    public async Task<IEnumerable<Consulta>> GetAllAsync() => await _context.Consultas.ToListAsync();
    public async Task CreateAsync(Consulta consulta)
    {
        _context.Consultas.Add(consulta);
        await _context.SaveChangesAsync();
    }
}
