using CognitiveServices.Web.Models;
using CognitiveServices.Web.Models.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CognitiveServices.Web.Services.Interfaces
{
    public interface ITextAnalyzeService
    {
        Task<List<Language>> DetectLanguagesAsync(TextViewModel textViewModel);
        Task<List<SentimentAnalyzes>> SentimentAnalyzesAsync(TextViewModel textViewModel);
    }
}
