using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NfcAdapters.Backend.ViewModels;
using NfcAdapters.Database;
using NfcAdapters.Database.Entities;

namespace NfcAdapters.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdapterTypeController : BaseController
    {

        public AdapterTypeController(AdapterContext context) : base(context)
        {
        }

        // GET: api/AdapterType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdapterTypeViewModel>>> GetAdapterTypes()
        {
            return new JsonResult((await AdapterContext.AdapterTypes
                .Include(e => e.Adapters)
                .ThenInclude(e => e.Lendings)
                .ToArrayAsync())
                .Select(e => new AdapterTypeViewModel(e)));
        }

        // GET: api/AdapterType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdapterType>> GetAdapterType(int id)
        {
            var adapterType = await AdapterContext.AdapterTypes.FindAsync(id);

            if (adapterType == null)
            {
                return NotFound();
            }

            return adapterType;
        }

        // PUT: api/AdapterType/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdapterType(int id, AdapterType adapterType)
        {
            if (id != adapterType.AdapterTypeId)
            {
                return BadRequest();
            }

            AdapterContext.Entry(adapterType).State = EntityState.Modified;

            try
            {
                await AdapterContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdapterTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AdapterType
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AdapterType>> PostAdapterType(AdapterType adapterType)
        {
            AdapterContext.AdapterTypes.Add(adapterType);
            await AdapterContext.SaveChangesAsync();

            return CreatedAtAction("GetAdapterType", new { id = adapterType.AdapterTypeId }, adapterType);
        }

        // DELETE: api/AdapterType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AdapterType>> DeleteAdapterType(int id)
        {
            var adapterType = await AdapterContext.AdapterTypes.FindAsync(id);
            if (adapterType == null)
            {
                return NotFound();
            }

            AdapterContext.AdapterTypes.Remove(adapterType);
            await AdapterContext.SaveChangesAsync();

            return adapterType;
        }

        private bool AdapterTypeExists(int id)
        {
            return AdapterContext.AdapterTypes.Any(e => e.AdapterTypeId == id);
        }
    }
}
