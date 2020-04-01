using Microsoft.Extensions.Caching.Distributed;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using WebApi.Models.Books;

namespace WebApi.BisinessLogic.Books
{
    public class CreateBookRequestHandler
    {
        private readonly IDistributedCache _distributedCache;
        public CreateBookRequestHandler(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<Guid> Create(Book book)
        {
            var id = Guid.NewGuid();

            var bookData = new BookData
            {
                Id = id,
                Price = book.Price,
                Title = book.Title,
            };
            
            var bf = new BinaryFormatter();

            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, bookData);
                var data = ms.ToArray();

                await _distributedCache.SetAsync($"Book_{id}", data);
            }

            return id;
        }
    }
}
