using BeinHazmanimFinderAPI.Models;
using BeinHazmanimFinderAPI.Repositories.Interfaces;
using BeinHazmanimFinderAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BeinHazmanimFinderAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AccommodationsController : ControllerBase
{
    private IAccommodationRepository _accommodationRepository;
    private IFinderQueryService _finderQueryService;
    public AccommodationsController(
        IAccommodationRepository accommodationRepository,
        IFinderQueryService finderQueryService)
    {
        _accommodationRepository = accommodationRepository;
        _finderQueryService = finderQueryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Accommodation>>> GetAll()
    {
        var result = await _accommodationRepository.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Accommodation>> GetById(int id)
    {
        Accommodation? existing = await _accommodationRepository.GetByIdAsync(id);
        if (existing == null)
        {
            return NotFound();
        }
        return Ok(existing);
    }

    [HttpPost]
    public async Task<ActionResult<Accommodation>> Create(Accommodation accommodation)
    {
        Accommodation created = await _accommodationRepository.CreateAsync(accommodation);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Accommodation accommodation)
    {
        Accommodation? updated = await _accommodationRepository.UpdateAsync(id, accommodation);
        if (updated == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        bool isDeleted = await _accommodationRepository.DeleteAsync(id);
        if (isDeleted == false)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpGet("search")]
    public ActionResult<IEnumerable<Accommodation>> Search(
        [FromQuery] string? city,
        [FromQuery] decimal? maxPrice,
        [FromQuery] bool? accessible
        )
    {
        var result = _finderQueryService.AccommodationsSearch(city, maxPrice, accessible);
        return Ok(result);
    }
}
