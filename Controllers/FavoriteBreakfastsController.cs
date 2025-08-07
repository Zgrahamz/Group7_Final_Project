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
    public class FavoriteBreakfastsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FavoriteBreakfastsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/FavoriteBreakfasts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteBreakfast>>> GetFavoriteBreakfasts()
        {
            return await _context.FavoriteBreakfasts.ToListAsync();
        }

        // GET: api/FavoriteBreakfasts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FavoriteBreakfast>> GetFavoriteBreakfast(int id)
        {
            var favoriteBreakfast = await _context.FavoriteBreakfasts.FindAsync(id);

            if (favoriteBreakfast == null)
            {
                return NotFound();
            }

            return favoriteBreakfast;
        }

        // PUT: api/FavoriteBreakfasts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavoriteBreakfast(int id, FavoriteBreakfast favoriteBreakfast)
        {
            if (id != favoriteBreakfast.Id)
            {
                return BadRequest();
            }

            _context.Entry(favoriteBreakfast).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteBreakfastExists(id))
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

        // POST: api/FavoriteBreakfasts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FavoriteBreakfast>> PostFavoriteBreakfast(FavoriteBreakfast favoriteBreakfast)
        {
            _context.FavoriteBreakfasts.Add(favoriteBreakfast);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavoriteBreakfast", new { id = favoriteBreakfast.Id }, favoriteBreakfast);
        }

        // DELETE: api/FavoriteBreakfasts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriteBreakfast(int id)
        {
            var favoriteBreakfast = await _context.FavoriteBreakfasts.FindAsync(id);
            if (favoriteBreakfast == null)
            {
                return NotFound();
            }

            _context.FavoriteBreakfasts.Remove(favoriteBreakfast);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavoriteBreakfastExists(int id)
        {
            return _context.FavoriteBreakfasts.Any(e => e.Id == id);
        }
    }
}
