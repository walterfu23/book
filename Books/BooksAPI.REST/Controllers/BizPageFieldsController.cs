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
    [Route("api/BizPageFields")]
    public class BizPageFieldsController : Controller
    {
        private readonly BooksDBContext context;
        public BizPageFieldsController(BooksDBContext context) => this.context = context;

        // GET: api/BizPageFields
        [HttpGet]
//        public IEnumerable<Author> Get() => context.Author.Include(a => a.Book).ThenInclude(b => b.Publisher);
        public IEnumerable<BizPageField> Get() => context.BizPageField;
    }
}