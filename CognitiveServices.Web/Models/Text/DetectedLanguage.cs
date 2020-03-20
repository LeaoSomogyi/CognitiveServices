using System;

namespace CognitiveServices.Web.Models.Text
{
    public class DetectedLanguage
    {
        public string Name { get; set; }
        public string Iso6391Name { get; set; }
        public decimal Score { get; set; }
        public decimal ScorePercentage => Math.Round(Score * 100);
    }
}
