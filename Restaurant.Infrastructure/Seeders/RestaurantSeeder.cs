using Microsoft.AspNetCore.Identity;
using Restaurant.Domain.Constants;
using Restaurant.Infrastructure.Contexts;

namespace Restaurant.Infrastructure.Seeders;

internal class RestaurantSeeder(AppDbContext _dbContext) : IRestaurantSeeder
{
    public async Task Seed()
    {
        if (await _dbContext.Database.CanConnectAsync())
        {
            if (!_dbContext.Restaurants.Any())
            {
                var restaurants = GetRestaurants();
                _dbContext.Restaurants.AddRange(restaurants);
                await _dbContext.SaveChangesAsync();
            }
            if (!_dbContext.Roles.Any())
            {
                var roles = GetRoles();
                _dbContext.Roles.AddRange(roles);
                await _dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<IdentityRole> GetRoles()
    {
        List<IdentityRole> roles =
            [
                new(UserRoles.User) { NormalizedName = UserRoles.User.ToUpper() },
                new(UserRoles.Owner) { NormalizedName = UserRoles.Owner.ToUpper() },
                new(UserRoles.Admin) { NormalizedName = UserRoles.Admin.ToUpper() }
            ];
        return roles;
    }

    private IEnumerable<Domain.Entities.Restaurant> GetRestaurants()
    {
        IEnumerable<Domain.Entities.Restaurant> restaurants = [

            new()
            {
                Name = "KFC",
                Category = "Fast Food",
                Description="This is description of Fast Food Restaurant",
                HasDelivery= true,
                Dishes =[
                    new(){
                        Name=" Chicken",
                         Description = "Fired Chicken",
                         Price = 10
                    },
                    new(){
                        Name = "chicken nuggets",
                        Description="chicken nuggets description",
                        Price = 5
                    }
                    ],
                Address = new(){
                    City = "london",
                    Street="Cork st 5",
                    PostalCode = "WC2N 5DU"
                },
                ContactEmail="KFC@gmail.com",
                ContactNumber= "+97568492997"

            },
            new()
            {
                Name = "McDonald",
                Category = "Fast Food",
                Description="This is description of Fast Food Restaurant",
                HasDelivery= true,
                Dishes =[
                    new(){
                        Name=" Burger",
                         Description = "Fired Burger",
                         Price = 11
                    },
                    new(){
                        Name = "chicken nuggets",
                        Description="chicken nuggets description",
                        Price = 6
                    }
                    ],
                Address = new(){
                    City = "New Yourk",
                    Street="Yourk st 5",
                    PostalCode = "M street 5DU"
                },
                ContactEmail="MC@gmail.com",
                ContactNumber= "+97500002997"

            }

            ];



        return restaurants;
    }
}
