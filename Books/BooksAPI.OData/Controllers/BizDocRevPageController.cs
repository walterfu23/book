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
    public class BizDocRevPageController : ODataController
    {
        private readonly BooksDBContext context;
        public BizDocRevPageController(BooksDBContext context) => this.context = context;

        // GET: odata/bizdoc
        [EnableQuery]
        public IQueryable<BizDocRevPage> Get() => 
            context.BizDocRevPage.AsQueryable();

        // GET: odata/bizDocRevPage(key)
        [EnableQuery]
        public SingleResult<BizDocRevPage> Get([FromODataUri]int key)
        {
            return SingleResult.Create(context.BizDocRevPage.Where(b => b.Id == key));
        }

        [EnableQuery]
        public IActionResult Post([FromBody] BizDocRevPage record)
        {
            try
            {
                context.BizDocRevPage.Add(record);
                context.SaveChanges();
                return Created(record);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        } // Post()

        [EnableQuery]
        public IActionResult Put(int key, [FromBody] BizDocRevPage record)
        {
            try
            {
                record.Id = key;
                context.BizDocRevPage.Update(record);
                context.SaveChanges();
                return Updated(record);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        } // Put()

        [EnableQuery]
        public IActionResult Patch(int key, [FromBody] Delta<BizDocRevPage> deltaRecord)
        {
            try
            {
                BizDocRevPage recordToPatch = context.BizDocRevPage.Find(key);
                if (null == recordToPatch)
                    return NotFound();

                deltaRecord.CopyChangedValues(recordToPatch);
                context.BizDocRevPage.Update(recordToPatch);
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
                BizDocRevPage recordToDelete = context.BizDocRevPage.Find(key);
                if (null == recordToDelete)
                    return NotFound();

                context.BizDocRevPage.Remove(recordToDelete);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    } // BizDocRevPageController
}
