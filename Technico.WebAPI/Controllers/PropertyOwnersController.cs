using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicoApp.Context;
using TechnicoApp.Services;

namespace Technico.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyOwnersController : ControllerBase
    {
        private readonly TechnicoDbContext _context;

        public PropertyOwnersController(TechnicoDbContext context)
        {
            _context = context;
        }

        // GET: api/PropertyOwners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyOwner>>> GetPropertyOwners()
        {
            return await _context.PropertyOwners.ToListAsync();
        }

        // GET: api/PropertyOwners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyOwner>> GetPropertyOwner(string id)
        {
            var propertyOwner = await _context.PropertyOwners.FindAsync(id);

            if (propertyOwner == null)
            {
                return NotFound();
            }

            return propertyOwner;
        }

        // PUT: api/PropertyOwners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPropertyOwner(string id, PropertyOwner propertyOwner)
        {
            if (id != propertyOwner.Id)
            {
                return BadRequest();
            }

            _context.Entry(propertyOwner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyOwnerExists(id))
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

        // POST: api/PropertyOwners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PropertyOwner>> PostPropertyOwner(PropertyOwner propertyOwner)
        {
            _context.PropertyOwners.Add(propertyOwner);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PropertyOwnerExists(propertyOwner.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPropertyOwner", new { id = propertyOwner.Id }, propertyOwner);
        }

        // DELETE: api/PropertyOwners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePropertyOwner(string id)
        {
            var propertyOwner = await _context.PropertyOwners.FindAsync(id);
            if (propertyOwner == null)
            {
                return NotFound();
            }

            _context.PropertyOwners.Remove(propertyOwner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PropertyOwnerExists(string id)
        {
            return _context.PropertyOwners.Any(e => e.Id == id);
        }
    }
}
