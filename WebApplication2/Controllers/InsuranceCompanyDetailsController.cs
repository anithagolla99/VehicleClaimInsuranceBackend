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
    public class InsuranceCompanyDetailsController : ControllerBase
    {
        private readonly VICMS_81258Context _context;

        public InsuranceCompanyDetailsController(VICMS_81258Context context)
        {
            _context = context;
        }

        // GET: api/InsuranceCompanyDetails
        [HttpGet]
        public IEnumerable<InsuranceCompanyDetails> GetInsuranceCompanyDetails()
        {
            return _context.InsuranceCompanyDetails;
        }

        // GET: api/InsuranceCompanyDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInsuranceCompanyDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var insuranceCompanyDetails = await _context.InsuranceCompanyDetails.FindAsync(id);

            if (insuranceCompanyDetails == null)
            {
                return NotFound();
            }

            return Ok(insuranceCompanyDetails);
        }

        // PUT: api/InsuranceCompanyDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsuranceCompanyDetails([FromRoute] int id, [FromBody] InsuranceCompanyDetails insuranceCompanyDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != insuranceCompanyDetails.ComapanyIdentificationNo)
            {
                return BadRequest();
            }

            _context.Entry(insuranceCompanyDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsuranceCompanyDetailsExists(id))
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

        // POST: api/InsuranceCompanyDetails
        [HttpPost]
        public async Task<IActionResult> PostInsuranceCompanyDetails([FromBody] InsuranceCompanyDetails insuranceCompanyDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.InsuranceCompanyDetails.Add(insuranceCompanyDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInsuranceCompanyDetails", new { id = insuranceCompanyDetails.ComapanyIdentificationNo }, insuranceCompanyDetails);
        }

        // DELETE: api/InsuranceCompanyDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsuranceCompanyDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var insuranceCompanyDetails = await _context.InsuranceCompanyDetails.FindAsync(id);
            if (insuranceCompanyDetails == null)
            {
                return NotFound();
            }

            _context.InsuranceCompanyDetails.Remove(insuranceCompanyDetails);
            await _context.SaveChangesAsync();

            return Ok(insuranceCompanyDetails);
        }

        private bool InsuranceCompanyDetailsExists(int id)
        {
            return _context.InsuranceCompanyDetails.Any(e => e.ComapanyIdentificationNo == id);
        }
    }
}