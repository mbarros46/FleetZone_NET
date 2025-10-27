using Swashbuckle.AspNetCore.Filters;
using FleetZone_NET.Application.DTOs;
using FleetZone_NET.Application.Common;

namespace FleetZone_NET.WebApi.SwaggerExamples
{
    public class MotocicletaRequestExample : IExamplesProvider<MotocicletaRequest>
    {
        public MotocicletaRequest GetExamples() => new()
        {
            Placa = "ABC1D23",
            Modelo = "Honda CG 160",
            PatioId = Guid.Parse("11111111-1111-1111-1111-111111111111")
        };
    }

    public class MotocicletaResponseExample : IExamplesProvider<MotocicletaResponse>
    {
        public MotocicletaResponse GetExamples() => new()
        {
            Id = 1,
            Placa = "ABC1D23",
            Modelo = "Honda CG 160",
            Status = "Disponivel",
            PatioId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Links = new[]
            {
                new LinkDto("self", "http://localhost:5049/api/v1/motocicletas/1", "GET"),
                new LinkDto("update", "http://localhost:5049/api/v1/motocicletas/1", "PUT"),
                new LinkDto("delete", "http://localhost:5049/api/v1/motocicletas/1", "DELETE")
            }
        };
    }
}
