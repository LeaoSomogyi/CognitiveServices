using System.Collections.Generic;

namespace CognitiveServices.Web.Models.Vision
{
    public class Analyze
    {
        public Description Description { get; set; }
        public List<Face> Faces { get; set; }
        public string Base64Image { get; set; }
    }
}
