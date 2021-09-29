using System;
using WebApi.Interfaces.Publish;

namespace WebApi.BusinessLogic.Books.Messages
{
    public class CreateBookMessage : Message
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}
