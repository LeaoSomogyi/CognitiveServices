using System.Collections.Generic;

namespace CognitiveServices.Web.Models.Vision
{
    public class Description
    {
        public string[] Tags { get; set; }
        public List<Captions> Captions { get; set; }
    }
}
