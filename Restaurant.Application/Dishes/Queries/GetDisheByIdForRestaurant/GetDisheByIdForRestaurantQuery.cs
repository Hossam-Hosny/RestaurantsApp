using MediatR;
using Restaurant.Application.Dishes.Dtos;

namespace Restaurant.Application.Dishes.Queries.GetDisheByIdForRestaurant;

public class GetDisheByIdForRestaurantQuery(int restaurantId , int dishId):IRequest<DishDto>
{
    public int RestaurantId { get; } = restaurantId;
    public int DishId { get; } = dishId;
}

