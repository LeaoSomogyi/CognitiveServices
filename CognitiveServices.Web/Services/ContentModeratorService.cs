using CognitiveServices.Web.Extensions;
using CognitiveServices.Web.Models;
using CognitiveServices.Web.Models.Configs;
using CognitiveServices.Web.Models.ContentModerator;
using CognitiveServices.Web.Services.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CognitiveServices.Web.Services
{
    public class ContentModeratorService : BaseClientService, IContentModeratorService
    {
        public ContentModeratorService(IHttpClientFactory clientFactory, IOptions<AzureCognitiveServicesConfig> options)
            : base(clientFactory, options) { }

        public async Task<Evaluate> EvaluateImageAsync(PhotoViewModel photoViewModel)
        {
            var bytes = await photoViewModel.File.GetRawBytes();

            using (var content = new ByteArrayContent(bytes))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                var response = await _httpClient.PostAsync("/contentmoderator/moderate/v1.0/ProcessImage/Evaluate", content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsJsonAsync<Evaluate>();
                }
                else
                    return null;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
