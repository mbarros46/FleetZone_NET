using Swashbuckle.AspNetCore.Filters;
using MottuCrudAPI.DTO.Request;

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
}
