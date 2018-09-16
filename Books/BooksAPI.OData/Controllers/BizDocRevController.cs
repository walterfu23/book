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
    public class BizDocRevController : ODataController
    {
        private readonly BooksDBContext context;
        public BizDocRevController(BooksDBContext context) => this.context = context;

        // GET: odata/bizdoc
        [EnableQuery]
        public IQueryable<BizDocRev> Get() => 
            context.BizDocRev.AsQueryable();

        // GET: odata/bizdocrev(key)
        [EnableQuery]
        public SingleResult<BizDocRev> Get([FromODataUri]int key)
        {
            return SingleResult.Create(context.BizDocRev.Where(b => b.Id == key));
        }

        [EnableQuery]
        public IActionResult Post([FromBody] BizDocRev record)
        {
            try
            {
                context.BizDocRev.Add(record);
                context.SaveChanges();
                return Created(record);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        } // Post()

        [EnableQuery]
        public IActionResult Put(int key, [FromBody] BizDocRev record)
        {
            try
            {
                record.Id = key;
                context.BizDocRev.Update(record);
                context.SaveChanges();
                return Updated(record);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        } // Put()

        [EnableQuery]
        public IActionResult Patch(int key, [FromBody] Delta<BizDocRev> deltaRecord)
        {
            try
            {
                BizDocRev recordToPatch = context.BizDocRev.Find(key);
                if (null == recordToPatch)
                    return NotFound();

                deltaRecord.CopyChangedValues(recordToPatch);
                context.BizDocRev.Update(recordToPatch);
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
                BizDocRev recordToDelete = context.BizDocRev.Find(key);
                if (null == recordToDelete)
                    return NotFound();

                context.BizDocRev.Remove(recordToDelete);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    } // BizDocRevController
}
