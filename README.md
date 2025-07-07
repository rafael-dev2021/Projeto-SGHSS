# 🏥 SGHSS_API - Sistema de Gestão Hospitalar e de Serviços de Saúde (Back-end)

Este projeto implementa a API de um sistema hospitalar fictício chamado **SGHSS**, desenvolvido com ASP.NET Core Minimal API, autenticação JWT, controle de acesso por perfil e logs com Serilog.

---

## 🔧 Tecnologias Utilizadas

- ✅ ASP.NET Core 6+ (Minimal API)
- ✅ InMemory Database
- ✅ JWT (Json Web Token)
- ✅ Autorização por Roles
- ✅ Serilog (logs no console e auditáveis)
- ✅ Swagger (para testes manuais da API)

---

## 🔐 Perfis e Autenticação

O sistema utiliza autenticação JWT com os seguintes perfis:

- `Admin`: Acesso completo (gestão de usuários e pacientes)
- `Paciente`: Acesso restrito à própria conta e agendamentos
- `Profissional`: Acesso a prontuários e pacientes

---

## 🚀 Como executar o projeto

1. Clone este repositório:
   ```bash
   git clone https://github.com/seu-usuario/SGHSS_API.git
   cd SGHSS_API
Restaure os pacotes e execute o projeto:

dotnet restore
dotnet run
Acesse o Swagger:


https://localhost:{porta}/swagger
Use o endpoint /api/login com as credenciais predefinidas para gerar o token JWT.

🔑 Login de Exemplo (usuários simulados)
Email	Senha	Perfil
admin@admin.com	123456	Admin
paciente@teste.com	123456	Paciente

📚 Principais Endpoints da API
Todos os endpoints (exceto login) exigem um token JWT válido.

🔐 Autenticação
POST /api/login
Retorna um token JWT.

👤 Usuários (Admin)
GET /api/admin/usuarios
Lista todos os usuários. Apenas Admin.

🧑 Pacientes
GET /api/pacientes
Lista todos os pacientes.

GET /api/pacientes/{id}
Retorna um paciente específico.

POST /api/pacientes
Cadastra um novo paciente. Apenas Admin.

📅 Consultas
GET /api/consultas
Lista todas as consultas.

POST /api/consultas
Cadastra uma nova consulta. Apenas Pacientes.

📄 Prontuários
GET /api/prontuarios/{id}
Retorna um prontuário específico. Apenas usuários autenticados.

👨‍⚕️ Profissionais
GET /api/profissionais
Lista todos os profissionais cadastrados.

📝 Logs com Serilog
Todas as ações são registradas com:

Email do usuário autenticado

Tipo de operação (leitura, criação, erro, tentativa inválida)

Identificador do recurso (ID)

📌 Requisitos Atendidos (segundo orientações do projeto)
 JWT com roles

 CRUD parcial para pacientes, consultas, prontuários

 Controle de acesso por perfil

 Uso de logs (Serilog)

 Documentação via Swagger

 Login e seed de usuários

 Projeto estruturado para deploy/entrega

📂 Organização de Código
SGHSS_API/
├── Models/
├── Repositories/
├── Context/
├── Endpoints/
├── Program.cs
├── README.md
🤝 Contribuição
Este projeto é acadêmico e individual. Contribuições externas não são aceitas.
