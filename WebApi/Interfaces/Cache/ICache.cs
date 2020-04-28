using System.Threading.Tasks;

namespace WebApi.Interfaces.Cache
{
    public interface ICache
    {
        string Get(string key);
        void Set(string key, string value);
        Task<string> GetAsync(string key);
        Task SetAsync(string key, string value);
    }
}
