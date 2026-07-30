using BeinHazmanimFinderAPI.Models;
using BeinHazmanimFinderAPI.Repositories;
using BeinHazmanimFinderAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeinHazmanimFinderAPI.Services;

public class FinderQueryService : IFinderQueryService
{
    private IActivityPlaceRepository _activityPlaceRepository;
    private IAccommodationRepository _accommodationRepository;
    public FinderQueryService(
        IAccommodationRepository accommodationRepository,
        IActivityPlaceRepository activityPlaceRepository)
    {
        _accommodationRepository = accommodationRepository;
        _activityPlaceRepository = activityPlaceRepository;
    }
    public async Task<List<Accommodation>> AccommodationsSearch(
         string? city,
         decimal? maxPrice,
         bool? accessible)
    {
        List<Accommodation> result = await _accommodationRepository.GetAllAsync();
        if (city != null && maxPrice != null && accessible != null)
        {
            result = result
                .OrderBy(a => a.PricePerNight)
                .Where(a => a.City == city && a.PricePerNight <= maxPrice && a.IsAccessible == accessible)
                .ToList();
        }
        else if (city != null && maxPrice != null)
        {
            result = result
                .OrderBy(a => a.PricePerNight)
                .Where(a => a.City == city && a.PricePerNight <= maxPrice)
                .ToList();
        }
        else if (maxPrice != null && accessible != null)
        {
            result = result
                .OrderBy(a => a.PricePerNight)
                .Where(a => a.PricePerNight <= maxPrice && a.IsAccessible == accessible)
                .ToList();
        }
        else if (city != null && accessible != null)
        {
            result = result
                .OrderBy(a => a.PricePerNight)
                .Where(a => a.City == city && a.IsAccessible == accessible)
                .ToList();
        }
        else if (city != null)
        {
            result = result
               .OrderBy(a => a.PricePerNight)
               .Where(a => a.City == city)
               .ToList();
        }
        else if (accessible != null)
        {
            result = result
                .OrderBy(a => a.PricePerNight)
                .Where(a => a.IsAccessible == accessible)
                .ToList();
        }
        else if (maxPrice != null)
        {

            result = result
                .OrderBy(a => a.PricePerNight)
                .Where(a => a.PricePerNight <= maxPrice)
                .ToList();
        }
        return result;
        
    }
    //public List<string> AccommodationsTypes()
    //{
    //    List<string> result = _accommodationRepository
    //        .GetAll()
    //        .GroupBy(a => a.AccommodationType)
    //        .Select()
    //}
}
