using Swashbuckle.AspNetCore.Filters;
using MottuCrudAPI.DTO.Request;
using MottuCrudAPI.DTO.Response;

namespace MottuCrudAPI.WebApi.SwaggerExamples
{
    public class PatioRequestExample : IExamplesProvider<PatioRequest>
    {
        public PatioRequest GetExamples() => new PatioRequest
        {
            Nome = "Pátio Central",
            Endereco = "Av. das Nações, 1000 - SP",
            Capacidade = 120
        };
    }

    public class PatioResponseExample : IExamplesProvider<PatioResponse>
    {
        public PatioResponse GetExamples() => new PatioResponse
        {
            Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Nome = "Pátio Central",
            Endereco = "Av. das Nações, 1000 - SP",
            Capacidade = 120,
            OcupacaoAtual = 45,
            Links = new[]
            {
                new LinkDto("self", "http://localhost:5049/api/v1/patio/11111111-1111-1111-1111-111111111111", "GET"),
                new LinkDto("update", "http://localhost:5049/api/v1/patio/11111111-1111-1111-1111-111111111111", "PUT"),
                new LinkDto("delete", "http://localhost:5049/api/v1/patio/11111111-1111-1111-1111-111111111111", "DELETE")
            }
        };
    }
}
