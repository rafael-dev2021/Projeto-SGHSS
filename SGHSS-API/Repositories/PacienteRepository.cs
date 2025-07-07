using Microsoft.EntityFrameworkCore;
using SGHSS_API.Context;
using SGHSS_API.Models;
using SGHSS_API.Repositories.Interfaces;

namespace SGHSS_API.Repositories;

public class PacienteRepository(SghssDbContext context) : IPacienteRepository
{
    private readonly SghssDbContext _context = context;

    public async Task<IEnumerable<Paciente>> GetAllAsync() => await _context.Pacientes.ToListAsync();
    public async Task<Paciente?> GetByIdAsync(Guid id) => await _context.Pacientes.FindAsync(id);
    public async Task CreateAsync(Paciente paciente)
    {
        _context.Pacientes.Add(paciente);
        await _context.SaveChangesAsync();
    }
}

