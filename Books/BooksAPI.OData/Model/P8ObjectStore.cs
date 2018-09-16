using System;
using System.Collections.Generic;

namespace BooksAPI.OData.Model
{
    public partial class P8ObjectStore
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string OsName { get; set; }
        public string OsLabel { get; set; }
        public string Description { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
        public string Modifier { get; set; }
        public DateTime ModTime { get; set; }
    }
}
