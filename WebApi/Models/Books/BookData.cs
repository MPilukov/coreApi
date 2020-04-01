using System;

namespace WebApi.Models.Books
{
    public class BookData
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}