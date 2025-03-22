using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nimbus.Shared;
using Nimbus.Shared.Entities;

namespace Nimbus.WebApi.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class AddressesController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        private readonly DataContext _context;

        public AddressesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Addresses
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<Microsoft.AspNetCore.Mvc.ActionResult<IEnumerable<Address>>> GetAddresses()
        {
            return await _context.Addresses.ToListAsync();
        }

        // GET: api/Addresses/5
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public async Task<Microsoft.AspNetCore.Mvc.ActionResult<Address>> GetAddress(int id)
        {
            var address = await _context.Addresses.FindAsync(id);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        // PUT: api/Addresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Microsoft.AspNetCore.Mvc.HttpPut("{id}")]
        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> PutAddress(int id, Address address)
        {
            if (id != address.id)
            {
                return BadRequest();
            }

            _context.Entry(address).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
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

        // POST: api/Addresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<Microsoft.AspNetCore.Mvc.ActionResult<Address>> PostAddress(Address address)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddress", new { id = address.id }, address);
        }

        // DELETE: api/Addresses/5
        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> DeleteAddress(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddressExists(int id)
        {
            return _context.Addresses.Any(e => e.id == id);
        }
    }
}
