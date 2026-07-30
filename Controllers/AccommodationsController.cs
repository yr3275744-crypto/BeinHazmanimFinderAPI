using BeinHazmanimFinderAPI.Models;
using BeinHazmanimFinderAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeinHazmanimFinderAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AccommodationsController : ControllerBase
{
    private IAccommodationRepository _accommodationRepository;
    public AccommodationsController(
        IAccommodationRepository accommodationRepository)
    {
        _accommodationRepository = accommodationRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Accommodation>> GetAll()
    {
        return _accommodationRepository.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Accommodation> GetById(int id)
    {
        Accommodation? existing = _accommodationRepository.GetById(id);
        if (existing == null)
        {
            return NotFound();
        }
        return Ok(existing);
    }

    [HttpPost]
    public ActionResult<Accommodation> Create(Accommodation accommodation)
    {
        Accommodation created = _accommodationRepository.Create(accommodation);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Accommodation accommodation)
    {
        Accommodation? updated = _accommodationRepository.Update(id, accommodation);
        if (updated == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        bool isDeleted = _accommodationRepository.Delete(id);
        if (isDeleted == false)
        {
            return NotFound();
        }
        return NoContent();
    }
}
