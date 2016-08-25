using Newtonsoft.Json;

namespace yaus.ViewModels.Out
{
    public class FetchUrlResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("fullUrl")]
        public string FullUrl { get; set; } 
    }
}