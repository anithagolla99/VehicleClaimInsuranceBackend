using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VICMAPI.Models;

namespace VICMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesController : ControllerBase
    {
        private readonly VICMS_81258Context _context;

        public PoliciesController(VICMS_81258Context context)
        {
            _context = context;
        }

        // GET: api/Policies
        [HttpGet]
        public IEnumerable<Policies> GetPolicies()
        {
            return _context.Policies;
        }

        // GET: api/Policies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPolicies([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var policies = await _context.Policies.FindAsync(id);

            if (policies == null)
            {
                return NotFound();
            }

            return Ok(policies);
        }

        // PUT: api/Policies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolicies([FromRoute] int id, [FromBody] Policies policies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != policies.PolicyId)
            {
                return BadRequest();
            }

            _context.Entry(policies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoliciesExists(id))
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

        // POST: api/Policies
        [HttpPost]
        public async Task<IActionResult> PostPolicies([FromBody] Policies policies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Policies.Add(policies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPolicies", new { id = policies.PolicyId }, policies);
        }

        // DELETE: api/Policies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolicies([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var policies = await _context.Policies.FindAsync(id);
            if (policies == null)
            {
                return NotFound();
            }

            _context.Policies.Remove(policies);
            await _context.SaveChangesAsync();

            return Ok(policies);
        }

        private bool PoliciesExists(int id)
        {
            return _context.Policies.Any(e => e.PolicyId == id);
        }
    }
}