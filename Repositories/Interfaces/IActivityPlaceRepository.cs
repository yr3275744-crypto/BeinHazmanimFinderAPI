using BeinHazmanimFinderAPI.Models;

namespace BeinHazmanimFinderAPI.Repositories.Interfaces;

public interface IActivityPlaceRepository
{
    public IEnumerable<ActivityPlace> GetAll();
    public ActivityPlace? GetById(int id);
    public ActivityPlace Create();
    public ActivityPlace? Update(int id);
    public bool Delete(int id);

}
