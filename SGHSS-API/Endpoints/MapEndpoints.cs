using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using SGHSS_API.Models;
using SGHSS_API.Repositories.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Serilog;

namespace SGHSS_API.Endpoints;

public static class MapEndpoints
{
    public static void AddMapEndpoints(this WebApplication app)
    {
        var jwtKey = "wYy2VvbrkJm23XExGg4M8I9qF7dI6eNqZ0QxX8YxT4kW5lV2NzN8XyY1Z9QvQ1";

        app.MapPost("/api/login", (UserLogin login, IUsuarioRepository repo) =>
        {
            var user = repo.ValidarUsuario(login.Email!, login.Senha!);

            if (user == null)
            {
                Log.Warning("Tentativa de login falhou para o e-mail: {Email}", login.Email);
                return Results.Unauthorized();
            }

            var claims = new[] {
                new Claim(ClaimTypes.Name, user.Email!),
                new Claim(ClaimTypes.Role, user.Perfil!)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);

            Log.Information("Usuário {Email} autenticado com sucesso.", user.Email);
            return Results.Ok(new { token = tokenStr });
        });

        app.MapGet("/api/admin/usuarios", [Authorize(Roles = "Admin")] (IUsuarioRepository repo, HttpContext context) =>
        {
            var userEmail = context.User.Identity?.Name ?? "desconhecido";
            Log.Information("Usuário administrador {User} requisitou a lista de usuários.", userEmail);

            return Results.Ok(repo.ListarUsuarios());
        });

        app.MapGet("/api/pacientes", [Authorize] async (IPacienteRepository repo, HttpContext context) =>
        {
            var userEmail = context.User.Identity?.Name ?? "desconhecido";
            Log.Information("Usuário {User} requisitou a lista de pacientes.", userEmail);

            return Results.Ok(await repo.GetAllAsync());
        });

        app.MapGet("/api/pacientes/{id}", async (Guid id, IPacienteRepository repo, HttpContext context) =>
        {
            var userEmail = context.User.Identity?.Name ?? "desconhecido";
            var paciente = await repo.GetByIdAsync(id);

            if (paciente is null)
            {
                Log.Warning("Usuário {User} tentou acessar paciente inexistente com ID: {Id}", userEmail, id);
                return Results.NotFound();
            }

            Log.Information("Usuário {User} acessou paciente com ID: {Id}", userEmail, id);
            return Results.Ok(paciente);
        });

        app.MapPost("/api/pacientes", async (Paciente paciente, IPacienteRepository repo, HttpContext context) =>
        {
            await repo.CreateAsync(paciente);
            var userEmail = context.User.Identity?.Name ?? "desconhecido";

            Log.Information("Usuário {User} criou novo paciente com ID: {Id}", userEmail, paciente.Id);
            return Results.Created($"/api/pacientes/{paciente.Id}", paciente);
        });

        app.MapPost("/api/consultas", [Authorize(Roles = "Paciente")] async (Consulta consulta, IConsultaRepository repo, HttpContext context) =>
        {
            await repo.CreateAsync(consulta);
            var userEmail = context.User.Identity?.Name ?? "desconhecido";

            Log.Information("Usuário {User} agendou uma nova consulta com ID: {Id}", userEmail, consulta.Id);
            return Results.Created($"/api/consultas/{consulta.Id}", consulta);
        });

        app.MapGet("/api/consultas", async (IConsultaRepository repo, HttpContext context) =>
        {
            var userEmail = context.User.Identity?.Name ?? "desconhecido";
            Log.Information("Usuário {User} acessou a lista de consultas.", userEmail);

            return Results.Ok(await repo.GetAllAsync());
        });

        app.MapGet("/api/prontuarios/{id}", [Authorize] async (
            Guid id,
            IProntuarioRepository repo,
            HttpContext context) =>
        {
            var prontuario = await repo.GetByIdAsync(id);
            var userEmail = context.User.Identity?.Name ?? "desconhecido";

            if (prontuario is null)
            {
                Log.Warning("Usuário {User} tentou acessar prontuário inexistente com ID: {Id}", userEmail, id);
                return Results.NotFound();
            }

            Log.Information("Usuário {User} acessou prontuário com ID: {Id}", userEmail, id);
            return Results.Ok(prontuario);
        });

        app.MapGet("/api/profissionais", [Authorize] async (
            IProfissionalRepository repo,
            HttpContext context) =>
        {
            var profissionais = await repo.GetAllAsync();
            var userEmail = context.User.Identity?.Name ?? "desconhecido";

            Log.Information("Usuário {User} acessou a lista de profissionais.", userEmail);
            return Results.Ok(profissionais);
        });
    }
}
