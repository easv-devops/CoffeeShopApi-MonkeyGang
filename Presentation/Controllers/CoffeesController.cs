namespace Controllers;

using Models;
using Data;




// using Microsoft.AspNetCore.Authorization; //ville være based, men vi skal lige kigge på det
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

//[Authorize(Roles = "Admin")] // Restrict access to users in the "Admin" role
//[Route("api/[controller]")]
[ApiController]
public class CoffeesController : ControllerBase
{
    private readonly CoffeeShopDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public CoffeesController(CoffeeShopDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // GET: api/coffees
    [HttpGet]
    public async Task<IActionResult> GetCoffees()
    {
        var coffees = await _context.Coffees.ToListAsync();
        return Ok(coffees);
    }

    // GET: api/coffees/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCoffee(int id)
    {
        var coffee = await _context.Coffees.FindAsync(id);

        if (coffee == null)
        {
            return NotFound();
        }

        return Ok(coffee);
    }

    // POST: api/coffees
    [HttpPost]
    public async Task<IActionResult> PostCoffee(Coffee coffee)
    {
        _context.Coffees.Add(coffee);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCoffee", new { id = coffee.Id }, coffee);
    }

    // PUT: api/coffees/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCoffee(Guid id, Coffee coffee)
    {
        if (id != coffee.Id)
        {
            return BadRequest();
        }

        _context.Entry(coffee).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CoffeeExists(id))
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

    // DELETE: api/coffees/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCoffee(int id)
    {
        var coffee = await _context.Coffees.FindAsync(id);
        if (coffee == null)
        {
            return NotFound();
        }

        _context.Coffees.Remove(coffee);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CoffeeExists(Guid id)
    {
        return _context.Coffees.Any(e => e.Id == id);
    }
}