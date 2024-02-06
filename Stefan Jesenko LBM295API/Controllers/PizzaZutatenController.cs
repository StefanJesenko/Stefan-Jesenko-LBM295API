using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stefan_Jesenko_LBM295API.Models;

namespace Stefan_Jesenko_LBM295API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaZutatenController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<PizzaZutaten>> PostPizzenZutaten(PizzaZutaten pizzaZutaten)
        {
            using (var _context = new PizzaDB())
            {
                _context.PizzaZutaten.Add(pizzaZutaten);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(PostPizzenZutaten), new { id = pizzaZutaten.Id }, pizzaZutaten); ;
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaZutaten>>> GetPizzenZutaten()
        {
            using (var _context = new PizzaDB())
            {
                return await _context.PizzaZutaten.ToListAsync();
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaZutaten>> GetPizzaZutat(int id)
        {
            using (var _context = new PizzaDB())
            {
                var person = await _context.PizzaZutaten.FindAsync(id);

                if (person == null)
                {
                    return NotFound();
                }

                return person;
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizzaZutaten(int id, PizzaZutaten pizzaZutaten)
        {
            if (id != pizzaZutaten.Id)
            {
                return BadRequest();
            }

            using (var _context = new PizzaDB())
            {
                _context.Entry(pizzaZutaten).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PizzaZutatenExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return Ok();
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<PizzaZutaten>> DeletePizzaZutaten(int id)
        {
            using (var _context = new PizzaDB())
            {
                var pizzaZutaten = await _context.PizzaZutaten.FindAsync(id);
                if (pizzaZutaten == null)
                {
                    return NotFound();
                }

                _context.PizzaZutaten.Remove(pizzaZutaten);
                await _context.SaveChangesAsync();

                return pizzaZutaten;
            }
        }

        private bool PizzaZutatenExists(int id)
        {
            using (var _context = new PizzaDB())
            {
                return _context.PizzaZutaten.Any(e => e.Id == id);
            }
        }
    }
}
