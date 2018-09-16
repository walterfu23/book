using System;
using System.Collections.Generic;

namespace BooksAPI.OData.Model
{
    public partial class DocDocType
    {
        public bool Active { get; set; }
        public int DocId { get; set; }
        public int DocTypeId { get; set; }
        public string Comment { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
        public string Modifier { get; set; }
        public DateTime ModTime { get; set; }

        public BizDoc Doc { get; set; }
        public DocType DocType { get; set; }
    }
}
