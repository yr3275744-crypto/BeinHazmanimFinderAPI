using BeinHazmanimFinderAPI.Models;
using BeinHazmanimFinderAPI.Repositories.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace BeinHazmanimFinderAPI.Repositories;

public class AccommodationRepository : IAccommodationRepository
{
    private readonly List<Accommodation> _accommodations =
        [
        new Accommodation
        {
            Id = 1,
            Name = "King David Suites",
            AccommodationType =  "Hotel",
            City = "Jerusalem",
            Area =  "City Center",
            KashrutAuthority = "Eida Charedit",
            PricePerNight = 950,
            MaximumGuests = 4,
            AvailableFrom = new DateTime(2026-08-01),
            IsAccessible =  true,
            IsAbroad = false
        },
        new Accommodation
        {
            Id = 2,
            Name = "Ramat Shlomo Apartment",
            AccommodationType = "Vacation Apartment",
            City = "Jerusalem",
            Area = "Ramat Shlomo",
            KashrutAuthority = "Eida Charedit",
            PricePerNight = 520,
            MaximumGuests = 6,
            AvailableFrom = new DateTime(2026-08-02),
            IsAccessible = false,
            IsAbroad = false
        }
        ];
    private int _nextId = 3;
    public IEnumerable<Accommodation> GetAll()
    {
        return _accommodations;
    }
    public Accommodation? GetById(int id)
    {
        Accommodation? accommodation = _accommodations
            .FirstOrDefault(accommodation => accommodation.Id == id);
        return accommodation;
    }
    public Accommodation Create(Accommodation accommodation)
    {
        accommodation.Id = _nextId;
        _nextId++;
        return accommodation;
    }
    public Accommodation? Update(int id, Accommodation accommodation)
    {
        Accommodation? existing = GetById(id);
        if (existing == null)
        {
            return null;
        }
        existing.Name = accommodation.Name;
        existing.AccommodationType = accommodation.AccommodationType;
        existing.City = accommodation.City;
        existing.Area = accommodation.Area;
        existing.KashrutAuthority = accommodation.KashrutAuthority;
        existing.PricePerNight = accommodation.PricePerNight;
        existing.MaximumGuests = accommodation.MaximumGuests;
        existing.AvailableFrom = accommodation.AvailableFrom;
        existing.IsAccessible = accommodation.IsAccessible;
        existing.IsAbroad = accommodation.IsAbroad;
        return existing;
    }
    public bool Delete(int id)
    {
        Accommodation? existing = GetById(id);
        if (existing == null)
        {
            return false;
        }
        _accommodations.Remove(existing);
        return true;
    }
}
