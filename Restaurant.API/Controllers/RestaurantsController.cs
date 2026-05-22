using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Restaurants.Commands.CreateRestaurant;
using Restaurant.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurant.Application.Restaurants.Queries.GetRestaurantById;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllRestaurantsQuery());
            return Ok(result);
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetRestaurantById([FromRoute]int id)
        {
            var result = await _mediator.Send(new GetRestaurantByIdQuery(id));

            if (result is null)
                return NotFound($"No Restaurant Found with that id:{id}");

            return Ok(result);
        }


        [HttpPost("create")]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand command)
        {
            int id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetRestaurantById), new { id }, null);
            
        }
    }
}
