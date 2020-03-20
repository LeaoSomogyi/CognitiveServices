using System.Collections.Generic;

namespace CognitiveServices.Web.Models.Text
{
    public class AnalyzeResult
    {
        public List<SentimentAnalyzes> Sentiment { get; set; }
        public List<Language> Language { get; set; }
    }
}
