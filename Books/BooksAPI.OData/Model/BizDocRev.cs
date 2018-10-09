using System;
using System.Collections.Generic;

namespace BooksAPI.OData.Model
{
    public partial class BizDocRev
    {
        public BizDocRev()
        {
            BizDocRevPage = new HashSet<BizDocRevPage>();
        }

        public int Id { get; set; }
        public int DocId { get; set; }
        public bool Active { get; set; }
        public string LangOrig { get; set; }
        public string LangNormalized { get; set; }
        public string RevOrig { get; set; }
        public string RevNormalized { get; set; }
        public string Comment { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
        public string Modifier { get; set; }
        public DateTime ModTime { get; set; }

        public BizDoc Doc { get; set; }
        public ICollection<BizDocRevPage> BizDocRevPage { get; set; }
    }
}
