# 🛵 FleetZone API – Advanced Business Development with .NET

API RESTful desenvolvida em **.NET 8 (Web API)** como parte do **Challenge 2025** (FIAP – 2º Ano ADS).
Projeto alinhado com boas práticas REST e com os requisitos da disciplina **Advanced Business Development with .NET**.

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

**Arquitetura utilizada:** Clean Architecture (Domain / Application / Infrastructure / WebApi)

---

## 🚀 Tecnologias Utilizadas
- ASP.NET Core 8 (Web API)
- Entity Framework Core (migrations + relational providers)
- Swagger / OpenAPI (Swashbuckle)
- ML.NET (endpoint de predição)
- xUnit para testes automatizados

---

## 🔧 Variáveis de Ambiente (exemplos PowerShell)

```powershell
$env:ConnectionStrings__Oracle = "Data Source=oracle.fiap.com.br:1521/orcl;User ID=RM556652;Password=123456;"
$env:ASPNETCORE_ENVIRONMENT = "Development"
$env:ASPNETCORE_HTTPS_PORT = "7208"
$env:ASPNETCORE_URLS = "http://localhost:5049;https://localhost:7208"
```

> As variáveis podem ser definidas na sessão do PowerShell ou via `appsettings.{Environment}.json`.

---

## ⚙️ Como Executar (rápido)

Pré-requisitos:
- .NET 8 SDK
- `dotnet-ef` (opcional para migrations)

Passos mínimos:

```powershell
# (1) Restaurar pacotes
dotnet restore

# (2) (Opcional) aplicar migrations / configurar DB
dotnet tool install --global dotnet-ef
dotnet ef database update

# (3) Executar a aplicação (perfil HTTPS recomendado)
# Ajuste o path se estiver abrindo a solução de outra pasta
dotnet run --project .\FleetZone_NET\ -c Debug --launch-profile https
```

URLs padrão (quando rodando localmente):
- HTTP: http://localhost:5049
- HTTPS: https://localhost:7208
- Swagger UI: https://localhost:7208/swagger

---

## 🌐 Endpoints Principais

> A API usa versionamento por rota: `api/v1/...`.

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

## 📌 Exemplos de Uso (cURL / PowerShell)

Se estiver usando o certificado de desenvolvimento e o endpoint HTTPS local, pode remover `-k`. Exemplo de chamadas abaixo usam o host padrão `https://localhost:7208`.

### Listar Motocicletas (paginação + HATEOAS)

```powershell
curl "https://localhost:7208/api/v1/motocicletas?pageNumber=1&pageSize=2"
```

### Criar um Pátio

```powershell
curl -X POST "https://localhost:7208/api/v1/patio" -H "Content-Type: application/json" -d '{
  "nome": "Pátio Central",
  "endereco": "Av. das Nações, 1000 - SP",
  "capacidade": 120
}'
```

**Observação importante:** as IDs de recursos no projeto são GUIDs. Use o GUID retornado no corpo das respostas para operações subsequentes.

### Exemplo: obter um pátio por ID (GUID)

```powershell
curl "https://localhost:7208/api/v1/patio/3f8f2c9b-7f9a-4a8d-9b2c-0a1b2c3d4e5f"
```

### Criar uma Movimentação (use GUIDs retornados pela API)

```powershell
curl -X POST "https://localhost:7208/api/v1/movimentacoes" -H "Content-Type: application/json" -d '{
  "tipo": "Entrada",
  "observacao": "Recebida do pátio Unidade 02",
  "motocicletaId": "a1b2c3d4-1111-2222-3333-444455556666",
  "patioId": "3f8f2c9b-7f9a-4a8d-9b2c-0a1b2c3d4e5f"
}'
```

### ML endpoint (Risk Predictor)

Endpoint: `POST /api/v1/ml/risk`

Exemplo de requisição com header de API Key (`X-API-KEY`). O valor padrão configurado no `appsettings.json` é `fleetzone-sprint4-key` (ajuste conforme seu ambiente).

Payload esperado (exemplo):

```json
{
  "RainMm": 50.0,
  "DrainageScore": 0.6,
  "Slope": 3.0,
  "PastFloods": 1.0
}
```

Exemplo de chamada (PowerShell / curl):

```powershell
curl -X POST "https://localhost:7208/api/v1/ml/risk" -H "Content-Type: application/json" -H "X-API-KEY: fleetzone-sprint4-key" -d '{
  "RainMm": 50.0,
  "DrainageScore": 0.6,
  "Slope": 3.0,
  "PastFloods": 1.0
}'
```

Resposta esperada (exemplo): 200 OK com JSON contendo IsHighRisk, Probability, Score.

---

## 📖 Swagger / OpenAPI

O Swagger está configurado com documentação e exemplos. Acesse: `https://localhost:7208/swagger` após subir a aplicação.

---

## 🧪 Testes Automatizados

Testes implementados com **xUnit** e `WebApplicationFactory<Program>` para integrações.

Rodar todos os testes:

```powershell
# Restaurar e testar
dotnet restore

dotnet test .\FleetZone_NET.Tests\ -c Release
```

Nota: os testes de integração executados localmente estão passando (4 testes, 0 falhas) no ambiente onde foram verificados; se repetir em outro host, rode `dotnet restore` antes.

---

## Checklist Sprint 4

- [x] Health Checks em `/health`
- [x] Versionamento por rota: `api/v1/...`
- [x] Segurança por API Key via header `X-API-KEY` (valor padrão `fleetzone-sprint4-key` em `appsettings.json`)
- [x] Endpoint ML.NET: `POST /api/v1/ml/risk`
- [x] Testes de integração com `WebApplicationFactory<Program>`

Observação: todos os requisitos funcionais da Sprint 4 estão implementados e os testes passam localmente. Itens opcionais que você pode querer adicionar:
- Centralizar versões de pacotes com `Directory.Packages.props` para evitar avisos de unificação de versão.
- Atualizar exemplos de configuração (ex.: strings de conexão) conforme seu ambiente.
