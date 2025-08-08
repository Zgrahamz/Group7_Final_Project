using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group7_Final_Project.EFCoreWebApi.Data;
using Group7_Final_Project.EFCoreWebApi.Models;

namespace Group7_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritePlanetsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FavoritePlanetsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/FavoritePlanets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoritePlanet>>> GetFavoritePlanets()
        {
            return await _context.FavoritePlanets.ToListAsync();
        }

        // GET: api/FavoritePlanets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FavoritePlanet>> GetFavoritePlanet(int id)
        {
            var favoritePlanet = await _context.FavoritePlanets.FindAsync(id);

            if (favoritePlanet == null)
            {
                return NotFound();
            }

            return favoritePlanet;
        }

        // PUT: api/FavoritePlanets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavoritePlanet(int id, FavoritePlanet favoritePlanet)
        {
            if (id != favoritePlanet.Id)
            {
                return BadRequest();
            }

            _context.Entry(favoritePlanet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoritePlanetExists(id))
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

        // POST: api/FavoritePlanets
        [HttpPost]
        public async Task<ActionResult<FavoritePlanet>> PostFavoritePlanet(FavoritePlanet favoritePlanet)
        {
            _context.FavoritePlanets.Add(favoritePlanet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavoritePlanet", new { id = favoritePlanet.Id }, favoritePlanet);
        }

        // DELETE: api/FavoritePlanets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoritePlanet(int id)
        {
            var favoritePlanet = await _context.FavoritePlanets.FindAsync(id);
            if (favoritePlanet == null)
            {
                return NotFound();
            }

            _context.FavoritePlanets.Remove(favoritePlanet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavoritePlanetExists(int id)
        {
            return _context.FavoritePlanets.Any(e => e.Id == id);
        }
    }
}
