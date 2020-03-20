using CognitiveServices.Web.Models;
using CognitiveServices.Web.Models.ContentModerator;
using System;
using System.Threading.Tasks;

namespace CognitiveServices.Web.Services.Interfaces
{
    public interface IContentModeratorService : IDisposable
    {
        Task<Evaluate> EvaluateImageAsync(PhotoViewModel photoViewModel);
    }
}
