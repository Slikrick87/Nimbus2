using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nimbus.Shared;
using Nimbus.Shared.Entities;
using Nimbus.Shared.DTOs;

namespace Nimbus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteEntitiesController : ControllerBase
    {
        private readonly DataContext _context;

        public RouteEntitiesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/RouteEntities
        //This one works!!!
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RouteEntityDTO>>> GetRoutes()
        {
            var routeEntities = await _context.Routes
                .Include(r => r.stops)
                .Include(r => r.truck)
                .ToListAsync();

            var routeDTOs = routeEntities.Select(routeEntity => new RouteEntityDTO
            {
                nickName = routeEntity.nickName,
                truck = routeEntity.truck != null ? new TruckEntityDTO
                {
                    Mileage = routeEntity.truck.mileage,
                    TireFDMileage = routeEntity.truck.tireFD,
                    TireRDMileage = routeEntity.truck.tireRD,
                    TireFPMileage = routeEntity.truck.tireFP,
                    TireRPMileage = routeEntity.truck.tireRP,
                    OilChangeMileage = routeEntity.truck.oilChange,
                } : null,
                stops = routeEntity.stops?.Select(s => new AddressEntityDTO
                {
                    streetNumber = s.streetNumber,
                    streetName = s.streetName,
                    city = s.city,
                    state = s.state,
                    zip = s.zipCode,
                }).ToList()
            }).ToList();

            return Ok(routeDTOs);
        }

        // GET: api/RouteEntities/5
        //works!
        [HttpGet("{id}")]
        public async Task<ActionResult<RouteEntityDTO>> GetRouteEntity(int id)
        {
            var routeEntity = await _context.Routes
                .Include(r => r.stops)
                .Include(r => r.truck)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (routeEntity == null)
            {
                return NotFound();
            }

            var routeDTO = new RouteEntityDTO
            {
                nickName = routeEntity.nickName,
                truck = routeEntity.truck != null ? new TruckEntityDTO
                {
                    Mileage = routeEntity.truck.mileage,
                    TireFDMileage = routeEntity.truck.tireFD,
                    TireRDMileage = routeEntity.truck.tireRD,
                    TireFPMileage = routeEntity.truck.tireFP,
                    TireRPMileage = routeEntity.truck.tireRP,
                    OilChangeMileage = routeEntity.truck.oilChange,
                } : null,
                stops = routeEntity.stops?.Select(s => new AddressEntityDTO
                {
                    streetNumber = s.streetNumber,
                    streetName = s.streetName,
                    city = s.city,
                    state = s.state,
                    zip = s.zipCode,
                }).ToList()
            };

            return Ok(routeDTO);
        }

        // PUT: api/RouteEntities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRouteEntity(int id, RouteEntity routeEntity)
        {
            if (id != routeEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(routeEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RouteEntityExists(id))
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

        // POST: api/RouteEntities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RouteEntity>> PostRouteEntity(RouteEntity routeEntity)
        {
            _context.Routes.Add(routeEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRouteEntity", new { id = routeEntity.Id }, routeEntity);
        }

        // DELETE: api/RouteEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRouteEntity(int id)
        {
            var routeEntity = await _context.Routes
                .Include(r => r.stops)
                .Include(r => r.truck)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (routeEntity == null)
            {
                return NotFound();
            }

            if (routeEntity.truck != null)
            {
                routeEntity.truck.routeId = null;
            }

            if (routeEntity.stops != null )
            {
                foreach (Address stop in routeEntity.stops)
                {
                    stop.routeId = null;
                }
            }
            _context.Routes.Remove(routeEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RouteEntityExists(int id)
        {
            return _context.Routes.Any(e => e.Id == id);
        }
    }
}
