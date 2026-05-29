using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories;
using Restaurant.Infrastructure.Contexts;

namespace Restaurant.Infrastructure.Repositories;

internal class DishRepository(AppDbContext _dbcontext) : IDishRepository
{
    public async Task<int> CreateAsync( Dish entity)
    {
        await _dbcontext.Dishes.AddAsync(entity);
        await _dbcontext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task Delete(List<Dish> dishes)
    {
       try
        {
            _dbcontext.Dishes.RemoveRange(dishes);
            await _dbcontext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public async Task DeleteDishesAsync(int id)
    {
      var restaurant =  await _dbcontext.Restaurants.FirstOrDefaultAsync(r => r.Id == id);
        _dbcontext.Dishes.RemoveRange(restaurant.Dishes);
        await _dbcontext.SaveChangesAsync();

    }

    public async Task<Dish?> GetByNameAsync(string name)
    {
      return  await _dbcontext.Dishes.FirstOrDefaultAsync(dish=>dish.Name == name);

    }
}
