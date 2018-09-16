using System;
using System.Collections.Generic;

namespace BooksAPI.REST.Model
{
    public partial class SubCategory
    {
        public SubCategory()
        {
            DocTypeSubCategory = new HashSet<DocTypeSubCategory>();
        }

        public int Id { get; set; }
        public int CatId { get; set; }
        public bool Active { get; set; }
        public string Val { get; set; }
        public string Name { get; set; }
        public int DispOrder { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
        public string Modifier { get; set; }
        public DateTime ModTime { get; set; }

        public Category Cat { get; set; }
        public ICollection<DocTypeSubCategory> DocTypeSubCategory { get; set; }
    }
}
