using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace FleetZone_NET.Tests.Integration;

public class ApiIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public ApiIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task HealthEndpoint_ReturnsOk()
    {
        var client = _factory.CreateClient();
        var resp = await client.GetAsync("/health");
        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
    }

    [Fact]
    public async Task MlEndpoint_WithApiKey_ReturnsPrediction()
    {
        var client = _factory.CreateClient();
        client.DefaultRequestHeaders.Add("X-API-KEY", "fleetzone-sprint4-key");

        var payload = new
        {
            RainMm = 50.0f,
            DrainageScore = 0.6f,
            Slope = 3.0f,
            PastFloods = 1.0f
        };

        var resp = await client.PostAsJsonAsync("/api/v1/ml/risk", payload);
        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);

        var obj = await resp.Content.ReadFromJsonAsync<System.Text.Json.JsonElement>();
        Assert.False(obj.ValueKind == System.Text.Json.JsonValueKind.Undefined);
    }
}
