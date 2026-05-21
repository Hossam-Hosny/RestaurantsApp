using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Restaurants.Dtos;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Restaurants;

internal class RestaurantsService(IRestaurantsRepository _restaurantRepository,
    ILogger<RestaurantsService> _logger, IMapper _mapper) : IRestaurantsService
{
    public async Task<int> CreateRestaurant(CreateRestaurantDto createRestaurantDto)
    {
        _logger.LogInformation("Creating a new Restaurant ");
        var restaurant = _mapper.Map<Domain.Entities.Restaurant>(createRestaurantDto);

        int id = await _restaurantRepository.CreateAysnc(restaurant);
        return id;
    }

    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {

        _logger.LogInformation("Getting All restaurants");
        var restaurants = await _restaurantRepository.GetAllAsync();
        
        var restaurantDto=_mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

        return restaurantDto!;

    }

    public async Task<RestaurantDto?> GetById(int id)
    {
        _logger.LogInformation("getting restaurant of id:{id}",id);
        var restaurant = await _restaurantRepository.GetByIdAsync(id);

        var restaurantDto = _mapper.Map<RestaurantDto?>(restaurant);
        return restaurantDto;
    }
}

