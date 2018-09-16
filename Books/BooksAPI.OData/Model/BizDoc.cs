using System;
using System.Collections.Generic;

namespace BooksAPI.OData.Model
{
    public partial class BizDoc
    {
        public BizDoc()
        {
            BizDocRev = new HashSet<BizDocRev>();
            DocDocType = new HashSet<DocDocType>();
        }

        public int Id { get; set; }
        public bool Active { get; set; }
        public string DocName { get; set; }
        public string DocNum { get; set; }
        public string Comment { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
        public string Modifier { get; set; }
        public DateTime ModTime { get; set; }

        public ICollection<BizDocRev> BizDocRev { get; set; }
        public ICollection<DocDocType> DocDocType { get; set; }
    }
}
