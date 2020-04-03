using System;

namespace WebApi.Models.Books
{
    [Serializable]
    public class Book
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}
