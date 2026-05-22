using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Restaurants.Dtos;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestaurantsQueryHandler(ILogger<GetAllRestaurantsQueryHandler> _logger , IRestaurantsRepository _restaurantRepository ,IMapper _mapper)
    : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantDto>>
{
    public async Task<IEnumerable<RestaurantDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting All restaurants");
        var restaurants = await _restaurantRepository.GetAllAsync();

        var restaurantDto = _mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

        return restaurantDto!;
    }
}
