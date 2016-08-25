using System.Threading.Tasks;

namespace yaus.Storage
{
    public interface IUrlStore
    {
        Task<bool> Store(string shortUrl, string fullUrl);
        Task<string> Fetch(string shortUrl);
    }
}