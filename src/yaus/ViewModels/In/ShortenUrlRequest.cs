using System;
using Newtonsoft.Json;

namespace yaus.ViewModels.In
{
    public class ShortenUrlRequest
    {
        [JsonProperty("fullUrl")]
        public string FullUrl { get; set; }

        public bool IsValid()
        {
            return Uri.IsWellFormedUriString(this.FullUrl, UriKind.Absolute);
        } 
    }
}