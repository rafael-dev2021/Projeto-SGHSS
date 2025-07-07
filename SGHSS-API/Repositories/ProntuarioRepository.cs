using Microsoft.EntityFrameworkCore;
using SGHSS_API.Context;
using SGHSS_API.Models;
using SGHSS_API.Repositories.Interfaces;

namespace SGHSS_API.Repositories;

public class ProntuarioRepository(SghssDbContext context) : IProntuarioRepository
{
    private readonly SghssDbContext _context = context;

    public async Task<IEnumerable<Prontuario>> GetAllAsync() => await _context.Prontuarios.ToListAsync();

    public async Task<Prontuario?> GetByIdAsync(Guid id) => 
      await _context.Prontuarios.FindAsync(id);
}
