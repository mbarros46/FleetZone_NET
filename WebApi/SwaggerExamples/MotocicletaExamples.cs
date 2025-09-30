using MottuCrudAPI.DTO.Request;
using Swashbuckle.AspNetCore.Filters;

namespace MottuCrudAPI.WebApi.SwaggerExamples;

public class MotocicletaRequestExample : IExamplesProvider<MotocicletaRequest>
{
    public MotocicletaRequest GetExamples() => new()
    {
        Placa = "ABC1D23",
        Modelo = "Honda CG 160",
        PatioId = 1
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
        PatioId = 1,
        Links = new[]
        {
            new LinkDto("self", "http://localhost:5049/api/v1/motocicletas/1", "GET"),
            new LinkDto("update", "http://localhost:5049/api/v1/motocicletas/1", "PUT"),
            new LinkDto("delete", "http://localhost:5049/api/v1/motocicletas/1", "DELETE")
        }
    };
}
