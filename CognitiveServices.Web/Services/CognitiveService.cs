using CognitiveServices.Web.Models;
using CognitiveServices.Web.Models.Text;
using CognitiveServices.Web.Models.Vision;
using CognitiveServices.Web.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace CognitiveServices.Web.Services
{
    public class CognitiveService : ICognitiveService
    {
        private readonly IContentModeratorService _contentModeratorService;
        private readonly IVisionService _visionService;
        private readonly ITextAnalyzeService _textAnalyzeService;

        public CognitiveService(IContentModeratorService contentModeratorService, IVisionService visionService,
            ITextAnalyzeService textAnalyzeService)
        {
            _contentModeratorService = contentModeratorService;
            _visionService = visionService;
            _textAnalyzeService = textAnalyzeService;
        }

        public async Task<bool> IsRestrictImageAsync(PhotoViewModel photoViewModel)
        {
            var evaluate = await _contentModeratorService.EvaluateImageAsync(photoViewModel);

            return (evaluate?.IsImageAdultClassified ?? false) || (evaluate?.IsImageRacyClassified ?? false);
        }

        public async Task<Analyze> AnalyzeImageAsync(PhotoViewModel photoViewModel)
        {
            return await _visionService.AnalyzeImageAsync(photoViewModel);
        }

        public async Task<AnalyzeResult> AnalyzeTextAsync(TextViewModel textViewModel) 
        {
            var languageTask = _textAnalyzeService.DetectLanguagesAsync(textViewModel);
            var sentimentTask = _textAnalyzeService.SentimentAnalyzesAsync(textViewModel);

            await Task.WhenAll(languageTask, sentimentTask);

            return new AnalyzeResult() 
            {
                Language = languageTask.Result,
                Sentiment = sentimentTask.Result
            };
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
