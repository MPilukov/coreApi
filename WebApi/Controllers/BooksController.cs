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

        public BooksController(GetBookInfoRequestHandler getBookInfoRequestHandler, IDistributedCache distributedCache)
        {
            _getBooknfoRequestHandler = getBookInfoRequestHandler;
            _distributedCache = distributedCache;
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

        [HttpGet("random")]
        public async Task<string> GetValue(int id)
        {
            var value = await _distributedCache.GetStringAsync("key");
            if (string.IsNullOrEmpty(value))
            {
                value = "new";
            }

            value = value + " 1 ";

            await _distributedCache.SetStringAsync("key", value);
            return value;
        }
    }
}