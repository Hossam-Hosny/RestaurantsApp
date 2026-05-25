using AutoMapper;
using Restaurant.Application.Dishes.Commands.CreateDish;
using Restaurant.Application.Dishes.Dtos;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Dishes;

public class DishsProfile:Profile
{
    public DishsProfile()
    {
        CreateMap<CreateDishCommand,Dish>();
        CreateMap<Dish,DishDto>();
    }
}
