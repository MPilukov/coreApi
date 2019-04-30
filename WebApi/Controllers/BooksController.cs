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
        private readonly GetBookInfoRequestHandler _getBooknfoRequestHandler;

        public BooksController(GetBookInfoRequestHandler getBookInfoRequestHandler)
        {
            _getBooknfoRequestHandler = getBookInfoRequestHandler;
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
    }
}