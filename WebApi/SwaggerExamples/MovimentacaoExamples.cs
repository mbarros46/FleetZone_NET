using Swashbuckle.AspNetCore.Filters;

namespace MottuCrudAPI.WebApi.SwaggerExamples;

public class MovimentacaoRequestExample : IExamplesProvider<MovimentacaoRequest>
{
    public MovimentacaoRequest GetExamples() => new()
    {
        Tipo = "Entrada",
        Observacao = "Recebida do pátio Unidade 02",
        MotocicletaId = 1,
        PatioId = 1
    };
}

public class MovimentacaoResponseExample : IExamplesProvider<MovimentacaoResponse>
{
    public MovimentacaoResponse GetExamples() => new()
    {
        Id = 10,
        DataHora = DateTime.UtcNow,
        Tipo = "Entrada",
        Observacao = "Recebida do pátio Unidade 02",
        MotocicletaId = 1,
        PatioId = 1,
        Links = new[]
        {
            new LinkDto("self", "http://localhost:5049/api/v1/movimentacoes/10", "GET"),
            new LinkDto("update", "http://localhost:5049/api/v1/movimentacoes/10", "PUT"),
            new LinkDto("delete", "http://localhost:5049/api/v1/movimentacoes/10", "DELETE")
        }
    };
}
