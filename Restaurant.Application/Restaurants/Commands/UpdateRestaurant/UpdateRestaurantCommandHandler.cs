using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler>_logger,IRestaurantsRepository _restaurantRepository,IMapper _mapper) : IRequestHandler<UpdateRestaurantCommand>
{
    public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("updateing restaurant of id: {RestaurantId} with {@UpdatedRestaurant}",request.Id,request);
        var restaurant = await _restaurantRepository.GetByIdAsync(request.Id);

        if (restaurant == null)
            throw new NotFoundException(nameof(Domain.Entities.Restaurant),request.Id.ToString());

        _mapper.Map(request, restaurant);

        await _restaurantRepository.UpdateAsync(restaurant);
      

    }
}
