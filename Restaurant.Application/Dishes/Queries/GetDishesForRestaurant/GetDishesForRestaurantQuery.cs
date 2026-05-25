using MediatR;
using Restaurant.Application.Dishes.Dtos;

namespace Restaurant.Application.Dishes.Queries.GetDishes;

public class GetDishesForRestaurantQuery(int restaurantId):IRequest<IEnumerable<DishDto>>
{
    public int restaurantId { get; } = restaurantId;
}
