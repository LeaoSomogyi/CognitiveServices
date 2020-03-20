using CognitiveServices.Web.Models.Configs;
using CognitiveServices.Web.Services;
using CognitiveServices.Web.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CognitiveServices.Web.Extensions
{
    /// <summary>
    /// Usefull methods for Startup
    /// </summary>
    public static class StartupExtensions
    {
        /// <summary>
        /// Configure all injectable services
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> service injection</param>
        public static IServiceCollection InjectServices(this IServiceCollection services) 
        {
            services.AddScoped<IContentModeratorService, ContentModeratorService>();
            services.AddScoped<IVisionService, VisionService>();
            services.AddScoped<ITextAnalyzeService, TextAnalyzeService>();
            services.AddScoped<ICognitiveService, CognitiveService>();

            return services;
        }

        /// <summary>
        /// Configure Settings
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> service injection</param>
        /// <param name="configuration">The <see cref="IConfiguration"/> configuration injection</param>
        public static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();

            services.Configure<AzureCognitiveServicesConfig>(configuration.GetSection("AzureCognitiveServicesConfig"));

            return services;
        }
    }
}
