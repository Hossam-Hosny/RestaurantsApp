using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler>_logger,IRestaurantsRepository _restaurantRepository,IMapper _mapper) : IRequestHandler<UpdateRestaurantCommand, bool>
{
    public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("updateing restaurant of id: {RestaurantId} with {@UpdatedRestaurant}",request.Id,request);
        var restaurant = await _restaurantRepository.GetByIdAsync(request.Id);

        if (restaurant == null)
            return false;

        _mapper.Map(request, restaurant);

        await _restaurantRepository.UpdateAsync(restaurant);
        return true;

    }
}
