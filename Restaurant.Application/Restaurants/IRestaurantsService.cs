

using Restaurant.Application.Restaurants.Dtos;

namespace Restaurant.Application.Restaurants
{
    public interface IRestaurantsService
    {
        Task<int> CreateRestaurant(CreateRestaurantDto createRestaurantDto);
        Task<IEnumerable<RestaurantDto>> GetAllRestaurants();
        Task<RestaurantDto?> GetById(int id);
    }
}