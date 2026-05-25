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

 

    public async Task<Dish?> GetByNameAsync(string name)
    {
      return  await _dbcontext.Dishes.FirstOrDefaultAsync(dish=>dish.Name == name);

    }
}
