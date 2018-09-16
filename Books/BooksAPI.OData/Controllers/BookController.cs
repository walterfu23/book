using BooksAPI.OData.Model;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.OData.Controllers
{
    [Produces("application/json")]
    public class BookController : ODataController
    {
        private readonly BooksDBContext context;
        public BookController(BooksDBContext context) => this.context = context;

        // GET: odata/book
        [EnableQuery]
        public IQueryable<Book> Get() => 
            context.Book.AsQueryable();

        // GET: odata/book(key)
        [EnableQuery]
//        public IActionResult Get(int key)       use SingleResult below instead
//        {
//            return Ok(context.Book.Find(key));
//        }
        public SingleResult<Book> Get([FromODataUri]int key)
        {
            return SingleResult.Create(context.Book.Where(b => b.Id == key));
        }

        [EnableQuery]
        public IActionResult Post([FromBody] Book book)
        {
            try
            {
                context.Book.Add(book);
                context.SaveChanges();
                return Created(book);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        } // Post()

        [EnableQuery]
        public IActionResult Put(int key, [FromBody] Book book)
        {
            try
            {
                book.Id = key;
                context.Book.Update(book);
                context.SaveChanges();
                return Updated(book);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        } // Put()

        [EnableQuery]
        public IActionResult Patch(int key, [FromBody] Delta<Book> deltaBook)
        {
            try
            {
                Book bookToPatch = context.Book.Find(key);
                if (null == bookToPatch)
                    return NotFound();

                deltaBook.CopyChangedValues(bookToPatch);
                context.Book.Update(bookToPatch);
                context.SaveChanges();
                return Updated(bookToPatch);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        } // Patch()


        [EnableQuery]
        public IActionResult Delete(int key)
        {
            try
            {
                Book bookToDelete = context.Book.Find(key);
                if (null == bookToDelete)
                    return NotFound();

                context.Book.Remove(bookToDelete);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    } // BookController
}
