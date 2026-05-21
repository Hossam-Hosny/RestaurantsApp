using AutoMapper;
using Restaurant.Application.Dishes.Dtos;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Dishes;

public class DishsProfile:Profile
{
    public DishsProfile()
    {
        CreateMap<Dish,DishDto>();
    }
}
