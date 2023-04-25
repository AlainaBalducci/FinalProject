using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantApi.Data;
using RestaurantApi.Models;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {

        //Instance of DB context created to be called and used throughout the controller.
        private readonly RestaurantDbContext _context;
        public RestaurantController(RestaurantDbContext context)
        {
            _context = context;
        }


        //Return all resturants from dbset.  
        [HttpGet]
        public async Task<IEnumerable<Restaurant>> Get()
        {
            return await _context.Restaurants.ToListAsync();
        }


        //Return information about individual resturant by using ID
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Restaurant), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var issue = await _context.Restaurants.FindAsync(id);
            return issue == null ? NotFound() : Ok(issue);
        }


        //Create a new resturant 
        [HttpPost]
        public async Task<IActionResult> Create(Restaurant restaurant)
        {
            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = restaurant.Id }, restaurant);
        }


        //Change information about the restuarant.  It can be grabbed by ID as the argument
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Restaurant restaurant)
        {
            if (id != restaurant.Id)

                return BadRequest();
            _context.Entry(restaurant).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }


        //Delete Restaurant in database.  Uses restaurant ID in argument.  
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var issueToDelete = await _context.Restaurants.FindAsync(id);
            if (issueToDelete == null) return NotFound();

            _context.Restaurants.Remove(issueToDelete);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
