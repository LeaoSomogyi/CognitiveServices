using CognitiveServices.Web.Models.Configs;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;

namespace CognitiveServices.Web.Services
{
    public abstract class BaseClientService
    {
        protected readonly HttpClient _httpClient;

        protected BaseClientService(IHttpClientFactory clientFactory, IOptions<AzureCognitiveServicesConfig> options)
        {
            _httpClient = clientFactory.CreateClient();
            var config = options.Value;

            _httpClient.BaseAddress = new Uri(config.Url);
            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", config.Key);
        }
    }
}
