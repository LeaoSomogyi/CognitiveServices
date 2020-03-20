using CognitiveServices.Web.Extensions;
using CognitiveServices.Web.Models;
using CognitiveServices.Web.Models.Configs;
using CognitiveServices.Web.Models.Vision;
using CognitiveServices.Web.Services.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace CognitiveServices.Web.Services
{
    public class VisionService : BaseClientService, IVisionService
    {
        public VisionService(IHttpClientFactory clientFactory, IOptions<AzureCognitiveServicesConfig> options)
            : base(clientFactory, options) { }

        public async Task<Analyze> AnalyzeImageAsync(PhotoViewModel photoViewModel)
        {
            var bytes = await photoViewModel.File.GetRawBytes();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            queryString["visualFeatures"] = "Description,Faces";
            queryString["language"] = "pt";

            using (var content = new ByteArrayContent(bytes))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                var response = await _httpClient.PostAsync($"/vision/v2.1/analyze?{queryString}", content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsJsonAsync<Analyze>(true);

                    result.Base64Image = await photoViewModel.File.ConvertToBase64();

                    return result;
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
