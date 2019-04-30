using System;
using System.Threading.Tasks;
using WebApi.Models.Books;

namespace WebApi.BisinessLogic.Books
{
    public class GetBookInfoRequestHandler
    {
        public Task<BookData> Get(Guid id)
        {
            var response = new BookData
            {
                Title = "Некое название",
                Id = id,
            };

            return Task.FromResult(response);
        }
    }
}