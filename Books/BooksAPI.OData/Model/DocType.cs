using System;
using System.Collections.Generic;

namespace BooksAPI.OData.Model
{
    public partial class DocType
    {
        public DocType()
        {
            DocDocType = new HashSet<DocDocType>();
            DocTypeSubCategory = new HashSet<DocTypeSubCategory>();
        }

        public int Id { get; set; }
        public int ListId { get; set; }
        public bool Active { get; set; }
        public string Val { get; set; }
        public string Name { get; set; }
        public int DispOrder { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
        public string Modifier { get; set; }
        public DateTime ModTime { get; set; }

        public List List { get; set; }
        public ICollection<DocDocType> DocDocType { get; set; }
        public ICollection<DocTypeSubCategory> DocTypeSubCategory { get; set; }
    }
}
