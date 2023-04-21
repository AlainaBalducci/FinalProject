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



    }
}
