using Microsoft.EntityFrameworkCore;
using SGHSS_API.Models;

namespace SGHSS_API.Context;

public class SghssDbContext : DbContext
{
    public SghssDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Paciente> Pacientes => Set<Paciente>();
    public DbSet<Consulta> Consultas => Set<Consulta>();
    public DbSet<ProfissionalSaude> Profissionais => Set<ProfissionalSaude>();
    public DbSet<Prontuario> Prontuarios => Set<Prontuario>();
    public DbSet<Usuario> Usuarios => Set<Usuario>();
}
