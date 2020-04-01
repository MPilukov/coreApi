using Microsoft.Extensions.Caching.Distributed;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using WebApi.Models.Books;

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
            var data = await _distributedCache.GetAsync($"Book_{id}");

            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(data))
            {
                var obj = formatter.Deserialize(ms);
                if (obj is BookData bookData)
                {
                    return bookData;
                }

                return null;
            }
        }
    }
}