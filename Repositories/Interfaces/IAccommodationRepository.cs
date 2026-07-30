using BeinHazmanimFinderAPI.Models;

namespace BeinHazmanimFinderAPI.Repositories.Interfaces;

public interface IAccommodationRepository
{
    public Task<List<Accommodation>> GetAllAsync();
    public Task<Accommodation?> GetByIdAsync(int id);
    public Task<Accommodation> CreateAsync(Accommodation accommodation);
    public Task<Accommodation?> UpdateAsync(int id, Accommodation accommodation);
    public Task<bool> DeleteAsync(int id);

}
