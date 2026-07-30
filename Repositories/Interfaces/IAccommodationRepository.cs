using BeinHazmanimFinderAPI.Models;

namespace BeinHazmanimFinderAPI.Repositories.Interfaces;

public interface IAccommodationRepository
{
    public IEnumerable<Accommodation> GetAll();
    public Accommodation? GetById(int id);
    public Accommodation Create(Accommodation accommodation);
    public Accommodation? Update(int id, Accommodation accommodation);
    public bool Delete(int id);

}
