using System;
using System.Collections.Generic;

namespace BooksAPI.REST.Model
{
    public partial class List
    {
        public List()
        {
            Category = new HashSet<Category>();
            DocType = new HashSet<DocType>();
        }

        public int Id { get; set; }
        public bool Active { get; set; }
        public string ListName { get; set; }
        public string ListLabel { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
        public string Modifier { get; set; }
        public DateTime ModTime { get; set; }

        public ICollection<Category> Category { get; set; }
        public ICollection<DocType> DocType { get; set; }
    }
}
