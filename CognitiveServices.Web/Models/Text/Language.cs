using System.Collections.Generic;

namespace CognitiveServices.Web.Models.Text
{
    public class Language
    {
        public int Id { get; set; }
        public List<DetectedLanguage> DetectedLanguages { get; set; }
    }
}
