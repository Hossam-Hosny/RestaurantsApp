using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> _logger, IRestaurantsRepository _restaurantRepository)
    : IRequestHandler<DeleteRestaurantCommand, bool>
{
   

    async Task<bool> IRequestHandler<DeleteRestaurantCommand, bool>.Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting restaurant with id: {id}", request.Id);
        var restaurant = await _restaurantRepository.GetByIdAsync(request.Id);

        if (restaurant == null)
            return false;

        await _restaurantRepository.DeleteAsync(restaurant);
        return true;
    }
}
