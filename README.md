# FleetZone API – Sprint 2 (.NET)

## Integrantes
- Pedro Merise (RM 556826)
- Miguel Barros Ramos (RM 556652)
- Thomas Rodrigues rm558042


## Domínio e Arquitetura
- Entidades principais: **Pátio**, **Motocicleta**, **Movimentação**.
- Justificativa: representam locais, ativos e eventos operacionais do cenário Mottu.
- Arquitetura: Clean Architecture (Domain, Application, Infrastructure, WebApi).

## Como executar
```bash
dotnet restore
dotnet ef database update        # se usar EF + migrations
dotnet run --project .
```

A API sobe em: http://localhost:5000

Swagger: http://localhost:5000/swagger

### Exemplos de uso (cURL)
# Listar pátios (paginado)
curl "http://localhost:5000/api/v1/patios?pageNumber=1&pageSize=10"

# Criar pátio
curl -X POST "http://localhost:5000/api/v1/patios" -H "Content-Type: application/json" -d '{
  "nome": "Pátio Central",
  "endereco": "Av. das Nações, 1000 - SP",
  "capacidade": 120
}'

### Testes
```bash
dotnet test
```

### Observações
- Paginação + HATEOAS presentes em todas as coleções.
- Status codes REST aplicados corretamente (200/201/204/400/404).
- Swagger com XML comments e exemplos de payload.
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



