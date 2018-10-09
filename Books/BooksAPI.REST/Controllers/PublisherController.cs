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
    [Route("api/Publishers")]
    public class PublisherController : Controller
    {
        private readonly BooksDBContext context;
        public PublisherController(BooksDBContext context) => this.context = context;

        // GET: api/Pubishers
        [HttpGet]
        public IEnumerable<Publisher> Get() => context.Publisher.Include(p => p.Book).ThenInclude(b=>b.Author);
    }
}