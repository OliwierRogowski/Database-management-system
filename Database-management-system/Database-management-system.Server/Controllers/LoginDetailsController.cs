using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database_management_system.Server.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.CodeAnalysis.Scripting;

namespace Database_management_system.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginDetailsController : ControllerBase
    {
        private readonly LoginDetailsContext _context;

        public class LoginRequest
        {
            public string Login { get; set; }
            public string Password { get; set; }
        }

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
        [HttpPost("checkCredentials")]
        public async Task<IActionResult> CheckCredentials([FromBody] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Password) || string.IsNullOrEmpty(request.Login))
                return BadRequest("Login and password can't be empty");

            // Sprawdzanie, czy użytkownik istnieje w bazie
            var user = await _context.LoginDetails
                .Where(u => u.LoginName == request.Login)
                .FirstOrDefaultAsync();

            if (user == null)
                return Unauthorized("Invalid login or password"); // Użytkownik nie znaleziony

            // Weryfikacja hasła
            bool passwordMatch = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);

            if (!passwordMatch)
                return Unauthorized("Invalid login or password"); // Złe hasło

            return Ok(true); // Użytkownik i hasło są poprawne
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
