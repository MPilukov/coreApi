using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.BisinessLogic.Books;
using WebApi.Models.Books;

namespace WebApi.Controllers
{
    [Route("api/books")]
    public class BooksController : Controller
    {
        private readonly GetBookInfoRequestHandler _getBookInfoRequestHandler;
        private readonly CreateBookRequestHandler _createBookRequestHandler;

        public BooksController(GetBookInfoRequestHandler getBookInfoRequestHandler, CreateBookRequestHandler createBookRequestHandler)
        {
            _getBookInfoRequestHandler = getBookInfoRequestHandler;
            _createBookRequestHandler = createBookRequestHandler;
        }

        [HttpGet("{id}")]
        public Task<Book> Get(Guid id)
        {
            return _getBookInfoRequestHandler.Get(id);
        }

        [HttpPost("")]
        public Task<Guid> Create([FromBody] Book book)
        {
            return _createBookRequestHandler.Create(book);
        }
    }
}