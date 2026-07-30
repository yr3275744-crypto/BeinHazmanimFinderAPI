using BeinHazmanimFinderAPI.Models;

namespace BeinHazmanimFinderAPI.Repositories.Interfaces;

public interface IActivityPlaceRepository
{
    public List<ActivityPlace> GetAll();
    public ActivityPlace? GetById(int id);
    public ActivityPlace Create(ActivityPlace activityPlace);
    public ActivityPlace? Update(int id, ActivityPlace activityPlace);
    public bool Delete(int id);

}
