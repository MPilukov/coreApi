using System;

namespace WebApi.Models.Books
{
    [Serializable]
    public class BookData
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}