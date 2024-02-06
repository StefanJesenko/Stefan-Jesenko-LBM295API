using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stefan_Jesenko_LBM295API.Models;

namespace Stefan_Jesenko_LBM295API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZutatenController : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Pizza>> AddZutat(Zutaten zutaten)
        {
            using (var _context = new PizzaDB())
            {
                _context.Zutaten.Add(zutaten);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(AddZutat), new { id = zutaten.Id }, zutaten);
            }


        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Zutaten>> GetZutat(int id)
        {
            using (var _context = new PizzaDB())
            {
                var zutaten = await _context.Zutaten.FindAsync(id);
                if (zutaten == null)
                {
                    return NotFound();
                }
                return zutaten;
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Zutaten>>> GetZutaten()
        {
            using (var _context = new PizzaDB())
            {
                return await _context.Zutaten.ToListAsync();
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateZutat(int id, Zutaten zutaten)
        {
            if (id != zutaten.Id)
            {
                return BadRequest();
            }

            using (var _context = new PizzaDB())
            {
                _context.Entry(zutaten).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Zutaten.Any(e => e.Id == id))
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
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteZutat(int id)
        {
            using (var _context = new PizzaDB())
            {
                var zutat = await _context.Zutaten.FindAsync(id);
                if (zutat == null)
                {
                    return NotFound();
                }

                _context.Zutaten.Remove(zutat);
                await _context.SaveChangesAsync();

                return NoContent();
            }
        }
    }
}
