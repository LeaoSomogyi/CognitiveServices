using Newtonsoft.Json.Linq;

namespace CognitiveServices.Web.Models.ContentModerator
{
    public class Evaluate
    {
        public decimal AdultClassificationScore { get; set; }
        public bool IsImageAdultClassified { get; set; }
        public bool RacyClassificationScore { get; set; }
        public bool IsImageRacyClassified { get; set; }
        public JArray AdvancedInfo { get; set; }
        public bool Result { get; set; }
        public Status Status { get; set; }
        public string TrackingId { get; set; }
    }
}
