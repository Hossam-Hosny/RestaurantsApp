using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> _logger, IRestaurantsRepository _restaurantRepository)
    : IRequestHandler<DeleteRestaurantCommand>
{
   

    async Task IRequestHandler<DeleteRestaurantCommand>.Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting restaurant with id: {RestaurantId}", request.Id);
        var restaurant = await _restaurantRepository.GetByIdAsync(request.Id);

        if (restaurant == null)
            throw new NotFoundException(nameof(Domain.Entities.Restaurant),request.Id.ToString());

        await _restaurantRepository.DeleteAsync(restaurant);
        
    }
}
