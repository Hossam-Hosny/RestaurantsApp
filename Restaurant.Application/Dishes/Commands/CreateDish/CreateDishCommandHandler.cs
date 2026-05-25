using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Dishes.Commands.CreateDish;

public class CreateDishCommandHandler(ILogger<CreateDishCommandHandler> _logger
    ,IDishRepository _dishRepository 
    ,IRestaurantsRepository _restaurantRepository
    , IMapper _mapper)
    : IRequestHandler<CreateDishCommand>
{
    public async Task Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating new dish {@DishRequest}",request);
        var restaurant = await _restaurantRepository.GetByIdAsync(request.RestaurantId)
            ?? throw new NotFoundException(nameof(Domain.Entities.Restaurant),request.RestaurantId.ToString());

        var existingDish = restaurant.Dishes.FirstOrDefault(dish => dish.Name == request.Name);
        if (existingDish is not null)
            throw new AlreadyExistException(nameof(Domain.Entities.Restaurant),
                request.RestaurantId.ToString(), 
                nameof(Dish), request.Name);


        var dish = _mapper.Map<Dish>(request);

        var dishId =  await _dishRepository.CreateAsync(dish);



    }
}
