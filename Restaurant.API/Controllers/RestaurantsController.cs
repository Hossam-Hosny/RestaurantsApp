using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Restaurants.Commands.CreateRestaurant;
using Restaurant.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurant.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurant.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurant.Application.Restaurants.Queries.GetRestaurantById;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllRestaurantsQuery());
            return Ok(result);
        }

        [HttpGet("get-restaurant/{id}")]
        public async Task<IActionResult> GetRestaurantById([FromRoute]int id)
        {
            var result = await _mediator.Send(new GetRestaurantByIdQuery(id));

            if (result is null)
                return NotFound($"No Restaurant Found with that id:{id}");

            return Ok(result);
        }

        [HttpDelete("delete-restaurant/{id}")]
        public async Task<IActionResult> DeleteRestaurant([FromRoute]int id)
        {
            bool isDeleted = await _mediator.Send(new DeleteRestaurantCommand(id));

            if (isDeleted)
                return NoContent();

            return NotFound();
        }


        [HttpPost("create")]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand command)
        {
            int id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetRestaurantById), new { id }, null);
            
        }

        [HttpPatch("update/{id}")]
        public async Task<IActionResult> UpdateRestaurant([FromRoute] int id , UpdateRestaurantCommand command)
        {
            command.Id = id;
            var isUpdated = await _mediator.Send(command);

            if (isUpdated)
                return NoContent();

            return NotFound($"No restaurant with that id: {id}");
        }
    }
}
