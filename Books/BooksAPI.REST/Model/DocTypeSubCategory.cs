using System;
using System.Collections.Generic;

namespace BooksAPI.REST.Model
{
    public partial class DocTypeSubCategory
    {
        public bool Active { get; set; }
        public int DocTypeId { get; set; }
        public int SubcatId { get; set; }
        public string Comment { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
        public string Modifier { get; set; }
        public DateTime ModTime { get; set; }

        public DocType DocType { get; set; }
        public SubCategory Subcat { get; set; }
    }
}
