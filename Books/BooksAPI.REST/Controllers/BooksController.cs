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
    [Route("api/Books")]
    public class BooksController : Controller
    {
        private readonly BooksDBContext context;
        public BooksController(BooksDBContext context) => this.context = context;

        // GET: api/Books
        [HttpGet]
        public IEnumerable<Book> Get() => context.Book.Include(b => b.Author).Include(b => b.Publisher);

        // POST: api/Book
        [HttpPost]
        public string HandlePost([FromBody] Book book)
        {
            int i = 123;
            return "abc";
        }


    }
}