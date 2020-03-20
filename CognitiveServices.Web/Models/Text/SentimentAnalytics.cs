using CognitiveServices.Web.Extensions;
using System;

namespace CognitiveServices.Web.Models.Text
{
    public class SentimentAnalyzes
    {
        public int Id { get; set; }
        public string Sentiment { get; set; }
        public DocumentScore DocumentScores { get; set; }

        public decimal SentimentPercentage() 
        {
            var property = DocumentScores?.GetType()?.GetProperty(Sentiment.ToUpperFirst());

            return Math.Round(Convert.ToDecimal(property?.GetValue(DocumentScores)) * 100);
        }
    }
}
