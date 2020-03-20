using System;

namespace CognitiveServices.Web.Models.Vision
{
    public class Captions
    {
        public string Text { get; set; }
        public decimal Confidence { get; set; }
        public decimal ConfidencePercentage => Math.Round(Confidence * 100, 2);
    }
}
