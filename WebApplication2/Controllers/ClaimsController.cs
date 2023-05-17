using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VICMAPI.Models;

namespace VICMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly VICMS_81258Context _context;

        public ClaimsController(VICMS_81258Context context)
        {
            _context = context;
        }
       
        // GET: api/Claims
        [HttpGet]
        public IEnumerable<Claims> GetClaims()
        {
            return _context.Claims;
        }

        // GET: api/Claims/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClaims([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var claims = await _context.Claims.FindAsync(id);

            if (claims == null)
            {
                return NotFound();
            }

            return Ok(claims);
        }

        // PUT: api/Claims/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClaims([FromRoute] int id, [FromBody] Claims claims)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != claims.ClaimId)
            {
                return BadRequest();
            }

            _context.Entry(claims).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClaimsExists(id))
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

        // POST: api/Claims
        [HttpPost]
        public async Task<IActionResult> PostClaims([FromBody] Claims claims)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Claims.Add(claims);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClaims", new { id = claims.ClaimId }, claims);
        }

        // DELETE: api/Claims/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClaims([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var claims = await _context.Claims.FindAsync(id);
            if (claims == null)
            {
                return NotFound();
            }

            _context.Claims.Remove(claims);
            await _context.SaveChangesAsync();

            return Ok(claims);
        }

        private bool ClaimsExists(int id)
        {
            return _context.Claims.Any(e => e.ClaimId == id);
        }
    }
}