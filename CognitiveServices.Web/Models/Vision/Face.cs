namespace CognitiveServices.Web.Models.Vision
{
    public class Face
    {
        public int Age { get; set; }
        public string Gender { get; set; }
        public string GenderDescription => Gender.Equals("Male") ? "Masculino" : "Feminino";
        public FaceRectangle FaceRectangle { get; set; }
    }
}
