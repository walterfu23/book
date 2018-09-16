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
    public class PublisherController : ODataController
    {
        private readonly BooksDBContext context;
        public PublisherController(BooksDBContext context) => this.context = context;

        // GET: odata/publisher
        [EnableQuery]
        public IQueryable<Publisher> Get() => context.Publisher.AsQueryable();
    }
}
