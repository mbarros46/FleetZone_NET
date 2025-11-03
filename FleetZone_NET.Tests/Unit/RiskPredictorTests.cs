using FleetZone_NET.ML;
using Xunit;

namespace FleetZone_NET.Tests.Unit;

public class RiskPredictorTests
{
    [Fact]
    public void Predict_ReturnsValidOutput()
    {
        // Arrange
        var predictor = new RiskPredictor();
        var input = new RiskInput { RainMm = 50f, DrainageScore = 0.6f, Slope = 3f, PastFloods = 1f };

        // Act
        var result = predictor.Predict(input);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<bool>(result.IsHighRisk);
        Assert.InRange(result.Probability, 0f, 1f);
    }
}
