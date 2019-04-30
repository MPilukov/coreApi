using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.BisinessLogic.Books;
using WebApi.Models.Books;

namespace WebApi.Controllers
{
    [Route("users")]
    public class BooksController : Controller
    {
        private readonly GetBookInfoRequestHandler _getBooknfoRequestHandler;
        
        // GET
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet()]
        public Task<BookData> Get(Guid id)
        {
            return _getBooknfoRequestHandler.Get(id);
        }
    }
}