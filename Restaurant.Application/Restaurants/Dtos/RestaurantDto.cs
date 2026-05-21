using Restaurant.Application.Dishes.Dtos;

namespace Restaurant.Application.Restaurants.Dtos;

public class RestaurantDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Category { get; set; } = default!;
    public bool HasDelivery { get; set; }

    public string? Street { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public List<DishDto> Dishes { get; set; } = [];


    public static RestaurantDto? FromEntity(  Domain.Entities.Restaurant? r)
    {
        if (r is null)return null;
        return new RestaurantDto
        {
            Id = r.Id,
            Name = r.Name,
            Category = r.Category,
            City = r.Address?.City,
            Street = r.Address?.Street,
            PostalCode = r.Address?.PostalCode,
            Description = r.Description,
            HasDelivery = r.HasDelivery,
            Dishes = r.Dishes.Select(DishDto.FromEntity).ToList()

        };
    }
}
