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
    public class BizDocController : ODataController
    {
        private readonly BooksDBContext context;
        public BizDocController(BooksDBContext context) => this.context = context;

        // GET: odata/bizdoc
        [EnableQuery]
        public IQueryable<BizDoc> Get() => 
            context.BizDoc.AsQueryable();

        // GET: odata/bizdoc(key)
        [EnableQuery]
        public SingleResult<BizDoc> Get([FromODataUri]int key)
        {
            return SingleResult.Create(context.BizDoc.Where(b => b.Id == key));
        }

        [EnableQuery]
        public IActionResult Post([FromBody] BizDoc record)
        {
            try
            {
                context.BizDoc.Add(record);
                context.SaveChanges();
                return Created(record);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        } // Post()

        [EnableQuery]
        public IActionResult Put(int key, [FromBody] BizDoc record)
        {
            try
            {
                record.Id = key;
                context.BizDoc.Update(record);
                context.SaveChanges();
                return Updated(record);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        } // Put()

        [EnableQuery]
        public IActionResult Patch(int key, [FromBody] Delta<BizDoc> deltaRecord)
        {
            try
            {
                BizDoc recordToPatch = context.BizDoc.Find(key);
                if (null == recordToPatch)
                    return NotFound();

                deltaRecord.CopyChangedValues(recordToPatch);
                context.BizDoc.Update(recordToPatch);
                context.SaveChanges();
                return Updated(recordToPatch);
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
                BizDoc recordToDelete = context.BizDoc.Find(key);
                if (null == recordToDelete)
                    return NotFound();

                context.BizDoc.Remove(recordToDelete);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    } // BizDocController
}
