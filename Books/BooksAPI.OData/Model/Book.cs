using System;
using System.Collections.Generic;

namespace BooksAPI.OData.Model
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public int? Edition { get; set; }

        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
    }
}
