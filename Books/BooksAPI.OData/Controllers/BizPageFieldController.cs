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
    public class BizPageFieldController : ODataController
    {
        private readonly BooksDBContext context;
        public BizPageFieldController(BooksDBContext context) => this.context = context;

        // GET: odata/BizPageField
        [EnableQuery]
        public IQueryable<BizPageField> Get() => 
            context.BizPageField.AsQueryable();

        // GET: odata/BizPageField(key)
        [EnableQuery]
        public SingleResult<BizPageField> Get([FromODataUri]int key)
        {
            return SingleResult.Create(context.BizPageField.Where(b => b.Id == key));
        }

        [EnableQuery]
        public IActionResult Post([FromBody] BizPageField record)
        {
            try
            {
                context.BizPageField.Add(record);
                context.SaveChanges();
                return Created(record);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        } // Post()

        [EnableQuery]
        public IActionResult Put(int key, [FromBody] BizPageField record)
        {
            try
            {
                record.Id = key;
                context.BizPageField.Update(record);
                context.SaveChanges();
                return Updated(record);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        } // Put()

        [EnableQuery]
        public IActionResult Patch(int key, [FromBody] Delta<BizPageField> deltaRecord)
        {
            try
            {
                BizPageField recordToPatch = context.BizPageField.Find(key);
                if (null == recordToPatch)
                    return NotFound();

                deltaRecord.CopyChangedValues(recordToPatch);
                context.BizPageField.Update(recordToPatch);
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
                BizPageField recordToDelete = context.BizPageField.Find(key);
                if (null == recordToDelete)
                    return NotFound();

                context.BizPageField.Remove(recordToDelete);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    } // BizPageFieldController
}
