
namespace Restaurant.Domain.Repositories;

public interface IRestaurantsRepository
{
    Task<int> CreateAysnc(Entities.Restaurant restaurant);
    Task<IEnumerable<Entities.Restaurant>> GetAllAsync();
    Task<Domain.Entities.Restaurant?> GetByIdAsync(int id);
    Task DeleteAsync(Domain.Entities.Restaurant restaurant);
    Task UpdateAsync(Domain.Entities.Restaurant entity);

}
