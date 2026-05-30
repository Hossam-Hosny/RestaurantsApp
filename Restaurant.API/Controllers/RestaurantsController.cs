using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Restaurants.Commands.CreateRestaurant;
using Restaurant.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurant.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurant.Application.Restaurants.Dtos;
using Restaurant.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurant.Application.Restaurants.Queries.GetRestaurantById;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RestaurantsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet("get-all")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllRestaurantsQuery());
            return Ok(result);
        }

        [HttpGet("get-restaurant/{id}")]
        public async Task<ActionResult<RestaurantDto?>> GetRestaurantById([FromRoute]int id)
        {
            var result = await _mediator.Send(new GetRestaurantByIdQuery(id));
             
            return Ok(result);
        }

        [HttpDelete("delete-restaurant/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRestaurant([FromRoute]int id)
        {
            await _mediator.Send(new DeleteRestaurantCommand(id));

            return NoContent();
        }


        [HttpPost("create")]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand command)
        {
            int id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetRestaurantById), new { id }, null);
            
        }

        [HttpPatch("update/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateRestaurant([FromRoute] int id , UpdateRestaurantCommand command)
        {
            command.Id = id;
             await _mediator.Send(command);

            return NoContent();
        }
    }
}
