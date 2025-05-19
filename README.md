# Mottu API - Sistema de Gerenciamento de Motos e Pátios

Este projeto é uma API RESTful desenvolvida para a Mottu, utilizando .NET 8 e Oracle Database, seguindo os princípios de Clean Architecture e Domain-Driven Design (DDD).

## 🚀 Tecnologias Utilizadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- Oracle Database
- AutoMapper
- Swagger/OpenAPI

## 📋 Pré-requisitos

- .NET 8 SDK
- Oracle Database
- Visual Studio 2022 ou VS Code

## 🔧 Configuração

1. Clone o repositório
2. Configure a string de conexão no arquivo `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "Oracle": "Data Source=seu_servidor:1521/seu_sid;User ID=seu_usuario;Password=sua_senha;"
  }
}
```

3. Execute as migrações do banco de dados:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

4. Execute o projeto:
```bash
dotnet run
```

## 📚 Rotas da API

### Motos

- GET /api/moto - Lista todas as motos
- GET /api/moto/{id} - Obtém uma moto específica
- POST /api/moto - Cria uma nova moto
- PUT /api/moto/{id} - Atualiza uma moto existente
- DELETE /api/moto/{id} - Remove uma moto

### Pátios

- GET /api/patio - Lista todos os pátios
- GET /api/patio/{id} - Obtém um pátio específico
- POST /api/patio - Cria um novo pátio
- PUT /api/patio/{id} - Atualiza um pátio existente
- DELETE /api/patio/{id} - Remove um pátio

## 📝 Documentação

A documentação da API está disponível através do Swagger UI quando o projeto está em execução:
- URL: https://localhost:5001/swagger



## 📄 Licença

Este projeto está sob a licença MIT.

## Autores

- Miguel Barros Ramos rm556652
- Pedro Valentim Merise rm556826

# 🛵 FleetZone .NET API

API Restful desenvolvida com ASP.NET Core para gerenciamento de motos, como parte da disciplina **Advanced Business Development with .NET** da FIAP.

---

## 🚀 Tecnologias Utilizadas

- ASP.NET Core 8
- Entity Framework Core (Oracle)
- Oracle.EntityFrameworkCore
- Swagger (Swashbuckle)
- EF Core Migrations
- RESTful API

---

## 📦 Como Executar

### Pré-requisitos

- .NET 8 SDK
- Oracle Database em funcionamento
- Ferramentas EF Core CLI (`dotnet tool install --global dotnet-ef`)

### Passos

```bash
# Restaurar pacotes
dotnet restore

# Aplicar migrations (se ainda não aplicou)
dotnet ef database update

# Rodar a aplicação
dotnet run



- Miguel Barros Ramos rm556652
- Pedro Valentim Merise rm556826
