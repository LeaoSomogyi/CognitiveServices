using CognitiveServices.Web.Extensions;
using CognitiveServices.Web.Models;
using CognitiveServices.Web.Models.Configs;
using CognitiveServices.Web.Models.Text;
using CognitiveServices.Web.Services.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CognitiveServices.Web.Services
{
    public class TextAnalyzeService : BaseClientService, ITextAnalyzeService
    {
        private static JsonSerializerSettings _serializerSettings
        {
            get
            {
                return new JsonSerializerSettings()
                {
                    ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() },
                    DateFormatString = "yyyy-MM-ddTHH:mm:ss",
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore,
                    Culture = new System.Globalization.CultureInfo("en-US"),
                    Formatting = Formatting.None,
                    FloatFormatHandling = FloatFormatHandling.DefaultValue,
                    FloatParseHandling = FloatParseHandling.Double,
                    TypeNameHandling = TypeNameHandling.None
                };
            }
        }

        public TextAnalyzeService(IHttpClientFactory clientFactory, IOptions<AzureCognitiveServicesConfig> options)
            : base(clientFactory, options) { }

        public async Task<List<Language>> DetectLanguagesAsync(TextViewModel textViewModel)
        {
            var payload = new
            {
                documents = new[]
                    {
                         new
                         {
                             id = "1",
                             text = textViewModel.Text
                         }
                    }
            };

            var json = JsonConvert.SerializeObject(payload, _serializerSettings);

            var bytes = Encoding.UTF8.GetBytes(json);

            using (var content = new ByteArrayContent(bytes))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await _httpClient.PostAsync("/text/analytics/v3.0-preview.1/languages", content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsJsonAsync<DynamicResponse<List<Language>>>(true);

                    return result.Documents ?? null;
                }
                else
                    return null;
            }
        }

        public async Task<List<SentimentAnalyzes>> SentimentAnalyzesAsync(TextViewModel textViewModel)
        {
            var payload = new
            {
                documents = new[]
                    {
                         new
                         {
                             id = "1",
                             text = textViewModel.Text
                         }
                    }
            };

            var json = JsonConvert.SerializeObject(payload, _serializerSettings);

            var bytes = Encoding.UTF8.GetBytes(json);

            using (var content = new ByteArrayContent(bytes))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await _httpClient.PostAsync("/text/analytics/v3.0-preview.1/sentiment", content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsJsonAsync<DynamicResponse<List<SentimentAnalyzes>>>(true);

                    return result.Documents ?? null;
                }
                else
                    return null;
            }
        }
    }
}
