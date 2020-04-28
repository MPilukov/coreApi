using System;
using System.Threading.Tasks;
using WebApi.Models.Books;
using WebApi.Interfaces.Publish;
using RabbitMq.Messages.Books;

namespace WebApi.BisinessLogic.Books
{
    public class CreateBookRequestHandler
    {
        private readonly IPublisher _publisher;

        public CreateBookRequestHandler(IPublisher publisher)
        {
            _publisher = publisher;
        }

        public Task<Guid> Create(Book book)
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

            //var data = JsonSerializer.Serialize<BookData>(bookData);
            //await _distributedCache.SetStringAsync($"Book_{id}", data);

            _publisher.Publish(new CreateBookMessage
            {
                Id = id,
                Price = book.Price,
                Title = book.Title,
            });

            return Task.FromResult(id);
        }
    }
}
