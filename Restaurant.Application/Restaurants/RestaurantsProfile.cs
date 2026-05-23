using AutoMapper;
using Restaurant.Application.Restaurants.Commands.CreateRestaurant;
using Restaurant.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurant.Application.Restaurants.Dtos;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Restaurants;

public class RestaurantsProfile:Profile
{
    public RestaurantsProfile()
    {
        CreateMap<UpdateRestaurantCommand,Domain.Entities.Restaurant>();

        CreateMap<CreateRestaurantCommand, Domain.Entities.Restaurant>()
            .ForMember(d => d.Address, opt => opt.MapFrom(
                src => new Address
                {
                    City = src.City,
                    Street = src.Street,
                    PostalCode = src.PostalCode
                }));


        CreateMap<Domain.Entities.Restaurant, RestaurantDto>()
            .ForMember(d => d.City, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.City))
            .ForMember(d => d.Street, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.Street))
            .ForMember(d => d.PostalCode, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.PostalCode))
            .ForMember(d=>d.Dishes ,opt=>opt.MapFrom(src=>src.Dishes));
    }
}
