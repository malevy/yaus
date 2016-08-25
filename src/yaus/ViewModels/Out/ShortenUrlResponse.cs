using Newtonsoft.Json;

namespace yaus.ViewModels.Out
{
    public class ShortenUrlResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; } 
    }
}