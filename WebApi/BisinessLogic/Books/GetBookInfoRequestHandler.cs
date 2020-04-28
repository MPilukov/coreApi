using System;
using System.Threading.Tasks;
using WebApi.Models.Books;
using System.Text.Json;
using WebApi.Interfaces.Cache;

namespace WebApi.BisinessLogic.Books
{
    public class GetBookInfoRequestHandler
    {
        private readonly ICache _cache;

        public GetBookInfoRequestHandler(ICache cache)
        {
            _cache = cache;
        }

        public async Task<BookData> Get(Guid id)
        {
            var data = await _cache.GetAsync($"Book_{id}");

            if (string.IsNullOrWhiteSpace(data))
            {
                return null;
            }

            var response = JsonSerializer.Deserialize<BookData>(data);
            return response;
        }
    }
}