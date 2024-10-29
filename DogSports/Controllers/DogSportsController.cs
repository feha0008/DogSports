using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DogSports.Models;

namespace DogSports.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogSportsController : ControllerBase
    {
        private readonly DogSportContext _context;

        public DogSportsController(DogSportContext context)
        {
            _context = context;
        }

        // GET: api/DogSports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DogSport>>> GetDogSports()
        {
          if (_context.DogSports == null)
          {
              return NotFound();
          }
            return await _context.DogSports.ToListAsync();
        }

        // GET: api/DogSports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DogSport>> GetDogSport(int id)
        {
          if (_context.DogSports == null)
          {
              return NotFound();
          }
            var dogSport = await _context.DogSports.FindAsync(id);

            if (dogSport == null)
            {
                return NotFound();
            }

            return dogSport;
        }

        // PUT: api/DogSports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDogSport(int id, DogSport dogSport)
        {
            if (id != dogSport.Id)
            {
                return BadRequest();
            }

            _context.Entry(dogSport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogSportExists(id))
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

        // POST: api/DogSports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DogSport>> PostDogSport(DogSport dogSport)
        {
          if (_context.DogSports == null)
          {
              return Problem("Entity set 'DogSportContext.DogSports'  is null.");
          }
            _context.DogSports.Add(dogSport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDogSport", new { id = dogSport.Id }, dogSport);
        }

        // DELETE: api/DogSports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDogSport(int id)
        {
            if (_context.DogSports == null)
            {
                return NotFound();
            }
            var dogSport = await _context.DogSports.FindAsync(id);
            if (dogSport == null)
            {
                return NotFound();
            }

            _context.DogSports.Remove(dogSport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DogSportExists(int id)
        {
            return (_context.DogSports?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
