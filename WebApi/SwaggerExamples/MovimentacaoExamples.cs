using Swashbuckle.AspNetCore.Filters;
using FleetZone_NET.Application.DTOs;
using FleetZone_NET.Application.Common;

namespace FleetZone_NET.WebApi.SwaggerExamples
{
    public class MovimentacaoRequestExample : IExamplesProvider<MovimentacaoRequest>
    {
        public MovimentacaoRequest GetExamples() => new()
        {
            Tipo = "Entrada",
            Observacao = "Recebida do pátio Unidade 02",
            MotocicletaId = 1,
            PatioId = Guid.Parse("11111111-1111-1111-1111-111111111111")
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
            PatioId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Links = new[]
            {
                new LinkDto("self", "http://localhost:5049/api/v1/movimentacoes/10", "GET"),
                new LinkDto("update", "http://localhost:5049/api/v1/movimentacoes/10", "PUT"),
                new LinkDto("delete", "http://localhost:5049/api/v1/movimentacoes/10", "DELETE")
            }
        };
    }
}
