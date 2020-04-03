using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading.Tasks;
using WebApi.Models.Books;
using System.Text.Json;

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
            //if (string.IsNullOrWhiteSpace(book.Title))
            //{
            //    throw new BadRequestException();
            //}

            var id = Guid.NewGuid();

            var bookData = new BookData
            {
                Id = id,
                Price = book.Price,
                Title = book.Title,
            };

            var data = JsonSerializer.Serialize<BookData>(bookData);

            await _distributedCache.SetStringAsync($"Book_{id}", data);
            
            return id;
        }
    }
}
