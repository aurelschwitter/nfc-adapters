using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NfcAdapters.Database;
using NfcAdapters.Database.Entities;

namespace NfcAdapters.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbUserController : BaseController
    {
        public DbUserController(AdapterContext context) : base(context)
        {}

        // GET: api/DbUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DbUser>>> GetDbUsers()
        {
            return await AdapterContext.DbUsers.ToListAsync();
        }

        // GET: api/DbUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DbUser>> GetDbUser(int id)
        {
            var dbUser = await AdapterContext.DbUsers.FindAsync(id);

            if (dbUser == null)
            {
                return NotFound();
            }

            return dbUser;
        }

        // PUT: api/DbUsers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDbUser(int id, DbUser dbUser)
        {
            if (id != dbUser.DbUserId)
            {
                return BadRequest();
            }

            AdapterContext.Entry(dbUser).State = EntityState.Modified;

            try
            {
                await AdapterContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DbUserExists(id))
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

        // POST: api/DbUsers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DbUser>> PostDbUser(DbUser dbUser, int adminId)
        {
            if (adminId != Convert.ToInt32(Startup.Configuration.GetSection("AdminKey").Value))
            {
                return Forbid();
            }

            AdapterContext.DbUsers.Add(dbUser);
            await AdapterContext.SaveChangesAsync();

            return CreatedAtAction("GetDbUser", new { id = dbUser.DbUserId }, dbUser);
        }

        // DELETE: api/DbUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DbUser>> DeleteDbUser(int id)
        {
            var dbUser = await AdapterContext.DbUsers.FindAsync(id);
            if (dbUser == null)
            {
                return NotFound();
            }

            AdapterContext.DbUsers.Remove(dbUser);
            await AdapterContext.SaveChangesAsync();

            return dbUser;
        }

        private bool DbUserExists(int id)
        {
            return AdapterContext.DbUsers.Any(e => e.DbUserId == id);
        }
    }
}
