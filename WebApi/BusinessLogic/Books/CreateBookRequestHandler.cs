using System;
using System.Threading.Tasks;
using WebApi.Models.Books;
using WebApi.Interfaces.Publish;
using Messages.Books;

namespace WebApi.BusinessLogic.Books
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
            var id = book.Id != Guid.Empty ? book.Id : Guid.NewGuid();

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
