using BeinHazmanimFinderAPI.Models;

namespace BeinHazmanimFinderAPI.Repositories.Interfaces;

public interface IAccommodationRepository
{
    public IEnumerable<Accommodation> GetAll();
    public Accommodation? GetById(int id);
    public Accommodation Create();
    public Accommodation? Update(int id);
    public bool Delete(int id);

}
