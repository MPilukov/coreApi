using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using WebApi.BisinessLogic.Books;
using WebApi.Models.Books;

namespace WebApi.Controllers
{
    [Route("api/books")]
    public class BooksController : Controller
    {
        private readonly GetBookInfoRequestHandler _getBooknfoRequestHandler;
        private readonly IDistributedCache _distributedCache;
        private readonly CreateBookRequestHandler _createBookRequestHandler;

        public BooksController(GetBookInfoRequestHandler getBookInfoRequestHandler, 
            IDistributedCache distributedCache, CreateBookRequestHandler createBookRequestHandler)
        {
            _getBooknfoRequestHandler = getBookInfoRequestHandler;
            _distributedCache = distributedCache;
            _createBookRequestHandler = createBookRequestHandler;
        }
        
        // GET
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public Task<BookData> Get(Guid id)
        {
            return _getBooknfoRequestHandler.Get(id);
        }

        [HttpPost("")]
        public Task<Guid> Create(Book book)
        {
            return _createBookRequestHandler.Create(book);
        }

        [HttpGet("random")]
        public async Task<string> GetValue()
        {
            var value = await _distributedCache.GetStringAsync("random_key");
            if (string.IsNullOrEmpty(value))
            {
                value = "new";
            }

            value = value + " 1 ";

            await _distributedCache.SetStringAsync("random_key", value);
            return value;
        }
    }
}