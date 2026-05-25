using Restaurant.Domain.Entities;

namespace Restaurant.Domain.Repositories;

public interface IDishRepository
{
    Task<int> CreateAsync( Dish entity);
    Task<Dish?> GetByNameAsync(string name);

}
