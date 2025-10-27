using Microsoft.ML;
using Microsoft.ML.Data;

namespace FleetZone_NET.ML
{
    public class RiskInput
    {
        public float RainMm { get; set; }
        public float DrainageScore { get; set; }
        public float Slope { get; set; }
        public float PastFloods { get; set; }
    }

    public class RiskOutput
    {
        public bool IsHighRisk { get; set; }
        public float Probability { get; set; }
        public float Score { get; set; }
    }

    internal class RiskLabel
    {
        [ColumnName("Label")]
        public bool Label { get; set; }

        [LoadColumn(0)] public float RainMm { get; set; }
        [LoadColumn(1)] public float DrainageScore { get; set; }
        [LoadColumn(2)] public float Slope { get; set; }
        [LoadColumn(3)] public float PastFloods { get; set; }
    }

    public class RiskPredictor
    {
        private readonly MLContext _ml;
        private PredictionEngine<RiskLabel, PredictedLabelResult> _engine;

        public RiskPredictor()
        {
            _ml = new MLContext(seed: 42);
            _engine = BuildAndTrain();
        }

        private PredictionEngine<RiskLabel, PredictedLabelResult> BuildAndTrain()
        {
            var data = new List<RiskLabel>
            {
                new() { RainMm = 20,  DrainageScore = 0.9f, Slope = 8,  PastFloods = 0, Label = false },
                new() { RainMm = 35,  DrainageScore = 0.7f, Slope = 6,  PastFloods = 1, Label = false },
                new() { RainMm = 60,  DrainageScore = 0.6f, Slope = 3,  PastFloods = 1, Label = true  },
                new() { RainMm = 80,  DrainageScore = 0.5f, Slope = 2,  PastFloods = 2, Label = true  },
                new() { RainMm = 120, DrainageScore = 0.4f, Slope = 1,  PastFloods = 3, Label = true  },
                new() { RainMm = 15,  DrainageScore = 0.95f,Slope = 10, PastFloods = 0, Label = false }
            };

            var dv = _ml.Data.LoadFromEnumerable(data);

            var pipeline = _ml.Transforms.Concatenate(
                                "Features",
                                nameof(RiskLabel.RainMm),
                                nameof(RiskLabel.DrainageScore),
                                nameof(RiskLabel.Slope),
                                nameof(RiskLabel.PastFloods))
                           .Append(_ml.BinaryClassification.Trainers.SdcaLogisticRegression());

            var model = pipeline.Fit(dv);
            return _ml.Model.CreatePredictionEngine<RiskLabel, PredictedLabelResult>(model);
        }

        public RiskOutput Predict(RiskInput input)
        {
            var label = new RiskLabel
            {
                RainMm = input.RainMm,
                DrainageScore = input.DrainageScore,
                Slope = input.Slope,
                PastFloods = input.PastFloods
            };

            var pred = _engine.Predict(label);
            return new RiskOutput
            {
                IsHighRisk = pred.Predicted,
                Probability = pred.Probability,
                Score = pred.Score
            };
        }

        private class PredictedLabelResult
        {
            [ColumnName("PredictedLabel")] public bool Predicted { get; set; }
            public float Probability { get; set; }
            public float Score { get; set; }
        }
    }
}
