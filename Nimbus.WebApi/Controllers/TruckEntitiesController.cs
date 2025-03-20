using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nimbus.Shared;
using Nimbus.Shared.Entities;

namespace Nimbus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckEntitiesController : ControllerBase
    {
        private readonly DataContext _context;

        public TruckEntitiesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/TruckEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TruckEntity>>> GetTrucks()
        {
            return await _context.Trucks.ToListAsync();
        }

        // GET: api/TruckEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TruckEntity>> GetTruckEntity(int id)
        {
            var truckEntity = await _context.Trucks.FindAsync(id);

            if (truckEntity == null)
            {
                return NotFound();
            }

            return truckEntity;
        }

        // PUT: api/TruckEntities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTruckEntity(int id, TruckEntity truckEntity)
        {
            if (id != truckEntity.id)
            {
                return BadRequest();
            }

            _context.Entry(truckEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TruckEntityExists(id))
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

        // POST: api/TruckEntities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TruckEntity>> PostTruckEntity(TruckEntity truckEntity)
        {
            _context.Trucks.Add(truckEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTruckEntity", new { id = truckEntity.id }, truckEntity);
        }

        // DELETE: api/TruckEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTruckEntity(int id)
        {
            var truckEntity = await _context.Trucks.FindAsync(id);
            if (truckEntity == null)
            {
                return NotFound();
            }

            _context.Trucks.Remove(truckEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TruckEntityExists(int id)
        {
            return _context.Trucks.Any(e => e.id == id);
        }
    }
}
