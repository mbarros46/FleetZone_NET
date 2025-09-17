# 🛵 FleetZone API – Advanced Business Development with .NET

API RESTful desenvolvida em **.NET 8 (Web API)** como parte do **Challenge 2025** (FIAP – 2º Ano ADS).  
Projeto alinhado com as boas práticas REST e com os requisitos da disciplina **Advanced Business Development with .NET**.

---

## 👨‍💻 Integrantes
- Pedro Valentim Merise – RM 556826
- Miguel Barros Ramos – RM 556652
- Thomas Rodrigues – RM 558042

---

## 📚 Domínio e Arquitetura

- **Entidades principais (mínimo 3):**
  - **Pátio** → representa os locais físicos onde as motos ficam.
  - **Motocicleta** → ativo principal gerenciado.
  - **Movimentação** → histórico de entrada, saída e realocação de motos.

**Justificativa do domínio:** Essas entidades traduzem diretamente o cenário da Mottu:  
controlar a infraestrutura (pátios), gerenciar os ativos (motocicletas) e registrar os eventos operacionais (movimentações).

**Arquitetura utilizada:** Clean Architecture  
- **Domain** → entidades, contratos e regras de negócio.  
- **Application** → DTOs, validações e casos de uso.  
- **Infrastructure** → persistência com EF Core (Oracle/SQLite).  
- **WebApi** → controllers REST, HATEOAS, versionamento, Swagger.

---

## 🚀 Tecnologias Utilizadas
- ASP.NET Core 8 (Web API)
- Entity Framework Core (com suporte a Oracle)
- EF Core Migrations
- Swagger / OpenAPI (Swashbuckle.AspNetCore + Filters)
- xUnit para testes automatizados

---

## ⚙️ Como Executar

### Pré-requisitos
- .NET 8 SDK instalado
- Banco Oracle ou SQLite configurado
- EF Core CLI:
  ```
  dotnet tool install --global dotnet-ef
  ```

### Passos
```
# Restaurar pacotes
dotnet restore

# Aplicar migrations no banco configurado
dotnet ef database update --project src/WebApi --startup-project src/WebApi

# Executar a aplicação
dotnet run --project src/WebApi
```

A API sobe em:  
➡️ `http://localhost:5000`  
➡️ Swagger UI: `http://localhost:5000/swagger`

---

## 🌐 Endpoints Principais

### Motocicletas
- `GET /api/v1/motocicletas?pageNumber=1&pageSize=10`
- `GET /api/v1/motocicletas/{id}`
- `POST /api/v1/motocicletas`
- `PUT /api/v1/motocicletas/{id}`
- `DELETE /api/v1/motocicletas/{id}`

### Pátios
- `GET /api/v1/patio?pageNumber=1&pageSize=10&nome=&endereco=`
- `GET /api/v1/patio/{id}`
- `POST /api/v1/patio`
- `PUT /api/v1/patio/{id}`
- `DELETE /api/v1/patio/{id}`

### Movimentações
- `GET /api/v1/movimentacoes?pageNumber=1&pageSize=10`
- `GET /api/v1/movimentacoes/{id}`
- `POST /api/v1/movimentacoes`
- `PUT /api/v1/movimentacoes/{id}`
- `DELETE /api/v1/movimentacoes/{id}`

---

## 📌 Exemplos de Uso (cURL)

### Criar um Pátio
```
curl -X POST "http://localhost:5000/api/v1/patio"   -H "Content-Type: application/json"   -d '{
    "nome": "Pátio Central",
    "endereco": "Av. das Nações, 1000 - SP",
    "capacidade": 120
  }'
```

### Listar Pátios (paginado e filtrado)
```
curl "http://localhost:5000/api/v1/patio?pageNumber=1&pageSize=10&nome=Central"
```

### Criar uma Motocicleta
```
curl -X POST "http://localhost:5000/api/v1/motocicletas"   -H "Content-Type: application/json"   -d '{
    "placa": "ABC1D23",
    "modelo": "CG 160",
    "status": "Disponivel"
  }'
```

---

## 📖 Swagger / OpenAPI

O Swagger está configurado com:
- Descrição de endpoints e parâmetros (via **XML Comments**)
- Exemplos de payloads (`SwaggerRequestExample`)
- Modelos de dados (DTOs) visíveis na UI

➡️ Acesse `http://localhost:5000/swagger` após rodar a aplicação.

---

## 🧪 Testes Automatizados

Os testes estão implementados com **xUnit** e cobrem:
- Regras de negócio das entidades
- Validações básicas
- Testes de integração com `WebApplicationFactory`

Rodar os testes:
```
dotnet test
```


