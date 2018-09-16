using System;
using System.Collections.Generic;

namespace BooksAPI.OData.Model
{
    public partial class BizDocRevPage
    {
        public int Id { get; set; }
        public int RevId { get; set; }
        public bool Active { get; set; }
        public int PgNum { get; set; }
        public string PgKey1 { get; set; }
        public string PgKey2 { get; set; }
        public string PgType { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
        public string Modifier { get; set; }
        public DateTime ModTime { get; set; }

        public BizDocRev Rev { get; set; }
    }
}
