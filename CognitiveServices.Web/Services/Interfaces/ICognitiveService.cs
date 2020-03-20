using CognitiveServices.Web.Models;
using CognitiveServices.Web.Models.Text;
using CognitiveServices.Web.Models.Vision;
using System;
using System.Threading.Tasks;

namespace CognitiveServices.Web.Services.Interfaces
{
    public interface ICognitiveService : IDisposable
    {
        Task<bool> IsRestrictImageAsync(PhotoViewModel photoViewModel);
        Task<Analyze> AnalyzeImageAsync(PhotoViewModel photoViewModel);
        Task<AnalyzeResult> AnalyzeTextAsync(TextViewModel textViewModel);
    }
}
