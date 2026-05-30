using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Users.Commands.AssignUserRole;
using Restaurant.Application.Users.Commands.UpdateUserDetails;
using Restaurant.Domain.Constants;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController(IMediator mediator) : ControllerBase
    {
        [HttpPatch("update")]
        [Authorize]
        public async Task<IActionResult> UpdateUserDetails (UpdateUserDetailsCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        
        [HttpPost("userRole")]
        [Authorize(Roles =UserRoles.Admin)]
        public async Task<IActionResult> AssignUserToRole (AssignUserRoleCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }








    }
}
