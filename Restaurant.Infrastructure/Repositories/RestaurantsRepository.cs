using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Repositories;
using Restaurant.Infrastructure.Contexts;

namespace Restaurant.Infrastructure.Repositories;

internal class RestaurantsRepository(AppDbContext _dbContext) : IRestaurantsRepository
{
    public async Task<int> CreateAysnc(Domain.Entities.Restaurant restaurant)
    {
        _dbContext.Add(restaurant);
        await _dbContext.SaveChangesAsync();
        return restaurant.Id;
    }

    public async Task DeleteAsync(Domain.Entities.Restaurant restaurant)
    {
        
        _dbContext.Remove(restaurant);
        await _dbContext.SaveChangesAsync();

    }

    public async Task<IEnumerable<Domain.Entities.Restaurant>> GetAllAsync()
    {
        var restaurants = await _dbContext.Restaurants.Include(d=>d.Dishes).ToListAsync();
        return restaurants;
    }

    public async Task<Domain.Entities.Restaurant?> GetByIdAsync(int id)
    {
        try
        {
            var restaurant = await _dbContext.Restaurants.Include(r => r.Dishes).FirstOrDefaultAsync(r => r.Id == id);
            return restaurant;
        }catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task UpdateAsync(Domain.Entities.Restaurant entity)
    {
        _dbContext.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}
