using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading.Tasks;
using WebApi.Models.Books;
using System.Text.Json;

namespace WebApi.BisinessLogic.Books
{
    public class GetBookInfoRequestHandler
    {
        private readonly IDistributedCache _distributedCache;

        public GetBookInfoRequestHandler(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<BookData> Get(Guid id)
        {
            var data = await _distributedCache.GetStringAsync($"Book_{id}");

            if (string.IsNullOrWhiteSpace(data))
            {
                return null;
            }

            var response = JsonSerializer.Deserialize<BookData>(data);
            return response;
        }
    }
}