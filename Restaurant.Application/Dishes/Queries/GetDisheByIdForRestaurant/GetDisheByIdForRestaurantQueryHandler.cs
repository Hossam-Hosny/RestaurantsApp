using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Dishes.Dtos;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Dishes.Queries.GetDisheByIdForRestaurant;

public class GetDisheByIdForRestaurantQueryHandler(ILogger<GetDisheByIdForRestaurantQueryHandler> logger,
    IRestaurantsRepository restaurantsRepository,
    IMapper mapper)
    : IRequestHandler<GetDisheByIdForRestaurantQuery, DishDto>
{
    public async Task<DishDto> Handle(GetDisheByIdForRestaurantQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Retriving Dish  of Id: {dishId} in restaurant {restaurantId}",request.DishId , request.RestaurantId);

        var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId)
            ?? throw new NotFoundException(nameof(Domain.Entities.Restaurant), request.RestaurantId.ToString());

        var dish = restaurant.Dishes.FirstOrDefault(dish => dish.Id == request.DishId)
            ?? throw new NotFoundException(nameof(Dish), request.DishId.ToString());

        var result = mapper.Map<DishDto>(dish);
        return result;
    }
}
