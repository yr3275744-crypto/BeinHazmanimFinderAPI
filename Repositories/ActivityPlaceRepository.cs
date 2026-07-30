using BeinHazmanimFinderAPI.Models;
using BeinHazmanimFinderAPI.Models.Enums;

namespace BeinHazmanimFinderAPI.Repositories;

public class ActivityPlaceRepository
{
    private readonly List<ActivityPlace> _activityPlaces =
        [
        new ActivityPlace
        {
            Id = 1,
            Name = "Cafe Rimon",
            Category = "Restaurant",
            City ="Jerusalem",
            Area = "City Center",
            TargetAudience = "Families",
            PricePerPerson = 90,
            MinimumAge = 0,
            AvailableDate = new DateTime(2026-08-01),
            IsAccessible = true,
            RequiresKashrut = true,
            KashrutAuthority = "Eida Charedit"
        },
        new ActivityPlace
        {
            Id = 2,
            Name = "Meat Grill House",
            Category = "Restaurant",
            City = "Bnei Brak",
            Area = "Rabbi Akiva",
            TargetAudience = TargetAudienceEnum.Adults,
            PricePerPerson = 140,
            MinimumAge = 0,
            AvailableDate = new DateTime(2026-08-02),
            IsAccessible = false,
            RequiresKashrut = true,
            KashrutAuthority = "Rav Landau"
        }
    ];
    private int _nextId = 3;

    public List<ActivityPlace> GetAll()
    {
        return _activityPlaces;
    }
    public ActivityPlace? GetById(int id)
    {
        ActivityPlace? activityPlace = _activityPlaces
            .FirstOrDefault(activityPlace => activityPlace.Id == id);
        return activityPlace;
    }
    public ActivityPlace Create(ActivityPlace activityPlace)
    {
        activityPlace.Id = _nextId;
        _nextId++;
        return activityPlace;
    }
    public ActivityPlace? Update(int id, ActivityPlace activityPlace)
    {
        ActivityPlace? existing = GetById(id);
        if (existing == null)
        {
            return null;
        }
        existing.Name = activityPlace.Name;
        existing.Category = activityPlace.Category;
        existing.City = activityPlace.City;
        existing.Area = activityPlace.Area;
        existing.TargetAudience = activityPlace.TargetAudience;
        existing.PricePerPerson = activityPlace.PricePerPerson;
        existing.MinimumAge = activityPlace.MinimumAge;
        existing.AvailableDate = activityPlace.AvailableDate;
        existing.IsAccessible = activityPlace.IsAccessible;
        existing.RequiresKashrut = activityPlace.RequiresKashrut;
        return existing;
    }

    public bool Delete(int id)
    {
        ActivityPlace? existing = GetById(id);
        if (existing == null)
        {
            return false;
        }
        _activityPlaces.Remove(existing);
        return true;
    }

}
