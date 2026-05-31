using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Exceptions;

namespace Restaurant.Application.Users.Commands.UnAssignUserRole;

public class UnAssignUserRoleCommandHandler(
    UserManager<User> userManager, RoleManager<IdentityRole> roleManager )
    : IRequestHandler<UnAssignUserRoleCommand>
{
    public async Task Handle(UnAssignUserRoleCommand request, CancellationToken cancellationToken)
    {
     //  logger.LogInformation("Un Assiging user-email: {userEmail}, to role: {roleName}" , request.UserEmail , request.RoleName);
        
        var user = await userManager.FindByEmailAsync(request.UserEmail)
            ??  throw new NotFoundException(nameof(User),request.UserEmail);

        var role = await roleManager.FindByNameAsync(request.RoleName)
            ?? throw new NotFoundException(nameof(IdentityRole) , request.RoleName);

        await userManager.RemoveFromRoleAsync(user, request.RoleName);


    }
}
