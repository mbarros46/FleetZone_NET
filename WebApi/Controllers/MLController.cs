using Microsoft.AspNetCore.Mvc;
using FleetZone_NET.ML;

namespace FleetZone_NET.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/ml")]
    public class MLController : ControllerBase
    {
        private readonly RiskPredictor _predictor;

        public MLController(RiskPredictor predictor)
        {
            _predictor = predictor;
        }

        public class RiskRequest
        {
            public float RainMm { get; set; }
            public float DrainageScore { get; set; }
            public float Slope { get; set; }
            public float PastFloods { get; set; }
        }

        public class RiskResponse
        {
            public bool IsHighRisk { get; set; }
            public float Probability { get; set; }
            public float Score { get; set; }
        }

        [HttpPost("risk")]
        public ActionResult<RiskResponse> Predict([FromBody] RiskRequest request)
        {
            var result = _predictor.Predict(new RiskInput
            {
                RainMm = request.RainMm,
                DrainageScore = request.DrainageScore,
                Slope = request.Slope,
                PastFloods = request.PastFloods
            });

            return Ok(new RiskResponse
            {
                IsHighRisk = result.IsHighRisk,
                Probability = result.Probability,
                Score = result.Score
            });
        }
    }
}
