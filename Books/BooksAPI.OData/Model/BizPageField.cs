using System;
using System.Collections.Generic;

namespace BooksAPI.OData.Model
{
    public partial class BizPageField
    {
        public int Id { get; set; }
        public int PgId { get; set; }
        public bool? Active { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string RegEx { get; set; }
        public int? X1 { get; set; }
        public int? Y1 { get; set; }
        public int? X2 { get; set; }
        public int? Y2 { get; set; }
        public string Comment { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
        public string Modifier { get; set; }
        public DateTime ModTime { get; set; }

        public BizDocRevPage Pg { get; set; }
    }
}
