using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database_management_system.Server.Models;

namespace Database_management_system.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginDetailsController : ControllerBase
    {
        private readonly LoginDetailsContext _context;

        public LoginDetailsController(LoginDetailsContext context)
        {
            _context = context;
        }

        // GET: api/LoginDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginDetails>>> GetLoginDetails()
        {
            return await _context.LoginDetails.ToListAsync();
        }

        // GET: api/LoginDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoginDetails>> GetLoginDetails(int id)
        {
            var loginDetails = await _context.LoginDetails.FindAsync(id);

            if (loginDetails == null)
            {
                return NotFound();
            }

            return loginDetails;
        }

        // PUT: api/LoginDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoginDetails(int id, LoginDetails loginDetails)
        {
            if (id != loginDetails.UserId)
            {
                return BadRequest();
            }

            _context.Entry(loginDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginDetailsExists(id))
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

        // POST: api/LoginDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoginDetails>> PostLoginDetails(LoginDetails loginDetails)
        {
            _context.LoginDetails.Add(loginDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoginDetails", new { id = loginDetails.UserId }, loginDetails);
        }

        // DELETE: api/LoginDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoginDetails(int id)
        {
            var loginDetails = await _context.LoginDetails.FindAsync(id);
            if (loginDetails == null)
            {
                return NotFound();
            }

            _context.LoginDetails.Remove(loginDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoginDetailsExists(int id)
        {
            return _context.LoginDetails.Any(e => e.UserId == id);
        }
    }
}
