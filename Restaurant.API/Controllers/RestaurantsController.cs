using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Restaurants;
using Restaurant.Application.Restaurants.Dtos;
using Restaurant.Infrastructure.Seeders;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController(IRestaurantsService _restaurantsService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _restaurantsService.GetAllRestaurants();


            return Ok(result);
        }
        [HttpGet("/{id}")]
        public async Task<IActionResult> GetRestaurantById([FromRoute]int id)
        {
            var result = await _restaurantsService.GetById(id);

            if (result is null)
                return NotFound($"No Restaurant Found with that id:{id}");

            return Ok(result);
        }


        [HttpPost("create")]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantDto createRestaurantDto)
        {
            int id = await _restaurantsService.CreateRestaurant(createRestaurantDto);
            return CreatedAtAction(nameof(GetRestaurantById), new { id }, null);
            
        }
    }
}
