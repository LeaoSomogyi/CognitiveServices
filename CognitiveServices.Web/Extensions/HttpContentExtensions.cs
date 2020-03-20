using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CognitiveServices.Web.Extensions
{
    public static class HttpContentExtensions
    {
        /// <summary>
        /// Json Serializer options adding SnakeCaseNamingStrategy
        /// </summary>
        private static JsonSerializerSettings SerializerSettings
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

        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content, bool useDefaulSettings = false)
        {
            string json = await content.ReadAsStringAsync();
            T value = useDefaulSettings ? JsonConvert.DeserializeObject<T>(json, SerializerSettings) : JsonConvert.DeserializeObject<T>(json);
            return value;
        }

        public static HttpContent SerializeAsJson(this object value, bool useDefaulSettings = false)
        {
            var serialized = useDefaulSettings ? JsonConvert.SerializeObject(value, SerializerSettings) : JsonConvert.SerializeObject(value);
            return new StringContent(serialized, Encoding.Default, "application/json");
        }
    }
}
