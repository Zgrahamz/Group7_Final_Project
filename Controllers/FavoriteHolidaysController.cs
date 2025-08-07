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
    public class FavoriteHolidaysController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FavoriteHolidaysController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/FavoriteHolidays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteHoliday>>> GetFavoriteHolidays()
        {
            return await _context.FavoriteHolidays.ToListAsync();
        }

        // GET: api/FavoriteHolidays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FavoriteHoliday>> GetFavoriteHoliday(int id)
        {
            var favoriteHoliday = await _context.FavoriteHolidays.FindAsync(id);

            if (favoriteHoliday == null)
            {
                return NotFound();
            }

            return favoriteHoliday;
        }

        // PUT: api/FavoriteHolidays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavoriteHoliday(int id, FavoriteHoliday favoriteHoliday)
        {
            if (id != favoriteHoliday.Id)
            {
                return BadRequest();
            }

            _context.Entry(favoriteHoliday).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteHolidayExists(id))
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

        // POST: api/FavoriteHolidays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FavoriteHoliday>> PostFavoriteHoliday(FavoriteHoliday favoriteHoliday)
        {
            _context.FavoriteHolidays.Add(favoriteHoliday);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavoriteHoliday", new { id = favoriteHoliday.Id }, favoriteHoliday);
        }

        // DELETE: api/FavoriteHolidays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriteHoliday(int id)
        {
            var favoriteHoliday = await _context.FavoriteHolidays.FindAsync(id);
            if (favoriteHoliday == null)
            {
                return NotFound();
            }

            _context.FavoriteHolidays.Remove(favoriteHoliday);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavoriteHolidayExists(int id)
        {
            return _context.FavoriteHolidays.Any(e => e.Id == id);
        }
    }
}
