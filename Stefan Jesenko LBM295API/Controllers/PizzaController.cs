using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stefan_Jesenko_LBM295API.Models;

namespace Stefan_Jesenko_LBM295API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        


        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Pizza>> AddPizza(Pizza pizza)
        {
            using (var _context = new PizzaDB())
            {
                _context.Pizzen.Add(pizza);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(AddPizza), new { id = pizza.Id }, pizza);
            }


        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Pizza>> GetPizza(int id)
        {
            using (var _context = new PizzaDB())
            {
                var pizza = await _context.Pizzen.FindAsync(id);
                if (pizza == null)
                {
                    return NotFound();
                }
                return pizza;
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetPizzas()
        {
            using (var _context = new PizzaDB())
            {
                return await _context.Pizzen.ToListAsync();
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdatePizza(int id, Pizza pizza)
        {
            if (id != pizza.Id)
            {
                return BadRequest();
            }

            using (var _context = new PizzaDB())
            {
                _context.Entry(pizza).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Pizzen.Any(e => e.Id == id))
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
        public async Task<IActionResult> DeletePizza(int id)
        {
            using (var _context = new PizzaDB())
            {
                var pizza = await _context.Pizzen.FindAsync(id);
                if (pizza == null)
                {
                    return NotFound();
                }

                _context.Pizzen.Remove(pizza);
                await _context.SaveChangesAsync();

                return NoContent();
            }
        }



        





    }





}




