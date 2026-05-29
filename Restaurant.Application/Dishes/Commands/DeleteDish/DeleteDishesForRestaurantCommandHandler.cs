using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Dishes.Commands.DeleteDish;

public class DeleteDishesForRestaurantCommandHandler(ILogger<DeleteDishesForRestaurantCommandHandler> logger,
    IRestaurantsRepository restaurantsRepository,
    IDishRepository dishRepository)
    : IRequestHandler<DeleteDishesForRestaurantCommand>
{
    public async Task Handle(DeleteDishesForRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogWarning("Removing all dishes from restaurant: {RestaurantId}",request.RestaurantId);

        var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId);
        if (restaurant == null) throw new NotFoundException(nameof(Domain.Entities.Restaurant), request.RestaurantId.ToString());

        logger.LogInformation("Trying to remove dishes of Restaurant; {RestaurantId}",request.RestaurantId);
        await  dishRepository.Delete(restaurant.Dishes);
        logger.LogInformation("Removing dishes of rRestaurant: {restaurantId} successfully done", request.RestaurantId);
    }
}
