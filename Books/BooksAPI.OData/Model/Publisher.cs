using System;
using System.Collections.Generic;

namespace BooksAPI.OData.Model
{
    public partial class Publisher
    {
        public Publisher()
        {
            Book = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Book> Book { get; set; }
    }
}
