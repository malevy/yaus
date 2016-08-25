using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace yaus.Storage.Impl
{
    public class MemoryUrlStore : IUrlStore
    {
        private readonly ConcurrentDictionary<string, string> _store = new ConcurrentDictionary<string, string>(); 

        public Task<bool> Store(string shortUrl, string fullUrl)
        {
            if (String.IsNullOrWhiteSpace(shortUrl))
                throw new ArgumentException("Argument is null or whitespace", nameof(shortUrl));
            if (String.IsNullOrWhiteSpace(fullUrl))
                throw new ArgumentException("Argument is null or whitespace", nameof(fullUrl));

            return Task.FromResult(_store.TryAdd(shortUrl, fullUrl)) ;
        }

        public Task<string> Fetch(string shortUrl)
        {
            string fullUrl;
            return Task.FromResult(_store.TryGetValue(shortUrl, out fullUrl) ? fullUrl : String.Empty) ;
        }
    }
}