using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler(IRestaurantsRepository _restaurantRepository,IMapper _mapper, ILogger<CreateRestaurantCommandHandler> _logger) : IRequestHandler<CreateRestaurantCommand, int>
{
    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating a new Restaurant {@Restaurant}",request);
        var restaurant = _mapper.Map<Domain.Entities.Restaurant>(request);

        int id = await _restaurantRepository.CreateAysnc(restaurant);
        return id;
    }
}
