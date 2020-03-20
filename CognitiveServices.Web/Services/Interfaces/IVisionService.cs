using CognitiveServices.Web.Models;
using CognitiveServices.Web.Models.Vision;
using System;
using System.Threading.Tasks;

namespace CognitiveServices.Web.Services.Interfaces
{
    public interface IVisionService : IDisposable
    {
        Task<Analyze> AnalyzeImageAsync(PhotoViewModel photoViewModel);
    }
}
