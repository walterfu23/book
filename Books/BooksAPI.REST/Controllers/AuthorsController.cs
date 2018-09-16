using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksAPI.REST.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksAPI.REST.Controllers
{
    [Produces("application/json")]
    [Route("api/Authors")]
    public class AuthorsController : Controller
    {
        private readonly BooksDBContext context;
        public AuthorsController(BooksDBContext context) => this.context = context;

        // GET: api/Authors
        [HttpGet]
        public IEnumerable<Author> Get() => context.Author.Include(a => a.Book).ThenInclude(b => b.Publisher);
    }
}