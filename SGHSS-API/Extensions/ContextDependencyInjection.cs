using Microsoft.EntityFrameworkCore;
using SGHSS_API.Context;
using SGHSS_API.Repositories;
using SGHSS_API.Repositories.Interfaces;

namespace SGHSS_API.Extensions;

public static class ContextDependencyInjection
{
    public static void AddContextDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SghssDbContext>(opt =>
        opt.UseInMemoryDatabase("SGHSS_DB"));

        services.AddScoped<IPacienteRepository, PacienteRepository>();
        services.AddScoped<IConsultaRepository, ConsultaRepository>();
        services.AddScoped<IProfissionalRepository, ProfissionalRepository>();
        services.AddScoped<IProntuarioRepository, ProntuarioRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
    }
}
