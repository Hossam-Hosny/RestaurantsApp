using MediatR;

namespace Restaurant.Application.Dishes.Commands.DeleteDish;

public class DeleteDishesForRestaurantCommand(int restaurantId):IRequest
{
    public int RestaurantId { get; } = restaurantId;
}
