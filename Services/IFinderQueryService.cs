using BeinHazmanimFinderAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeinHazmanimFinderAPI.Services;

public interface IFinderQueryService
{
     Task<List<Accommodation>> AccommodationsSearch(
        string? city,
        decimal? maxPrice,
        bool? accessible);
    Task<List<string>> AccommodationsTypes();
}
