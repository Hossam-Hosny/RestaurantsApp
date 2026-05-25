using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Restaurants.Dtos;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Restaurants.Queries.GetRestaurantById;

public class GetRestaurantByIdQueryHandler(ILogger<GetRestaurantByIdQueryHandler> _logger, IMapper _mapper,IRestaurantsRepository _restaurantRepository)
    : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto>
{
    public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("getting restaurant of id:{RestaurantId}", request.Id);
        var restaurant = await _restaurantRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Domain.Entities.Restaurant), request.Id.ToString()); ;

        var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);
        return restaurantDto;
    }
}
