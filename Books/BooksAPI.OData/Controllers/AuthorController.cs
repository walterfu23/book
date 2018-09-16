using BooksAPI.OData.Model;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.OData.Controllers
{
    [Produces("application/json")]
    public class AuthorController : ODataController
    {
        private readonly BooksDBContext context;
        public AuthorController(BooksDBContext context) => this.context = context;

        // GET: odata/Author
        [EnableQuery]
        public IQueryable<Author> Get() => context.Author.AsQueryable();
    }
}
