using BeinHazmanimFinderAPI.Models;
using BeinHazmanimFinderAPI.Repositories;
using BeinHazmanimFinderAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeinHazmanimFinderAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivityPlacesController : ControllerBase
{
    private IActivityPlaceRepository _activityPlaceRepository;
    public ActivityPlacesController(IActivityPlaceRepository activityPlaceRepository)
    {
        _activityPlaceRepository = activityPlaceRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ActivityPlace>> GetAll()
    {
        return _activityPlaceRepository.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<ActivityPlace> GetById(int id)
    {
        ActivityPlace? existing = _activityPlaceRepository.GetById(id);
        if (existing == null)
        {
            return NotFound();
        }
        return Ok(existing);
    }

    [HttpPost]
    public ActionResult<ActivityPlace> Create(ActivityPlace activityPlace)
    {
        ActivityPlace created = _activityPlaceRepository.Create(activityPlace);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, ActivityPlace activityPlace)
    {
        ActivityPlace? updated = _activityPlaceRepository.Update(id, activityPlace);
        if (updated == null)
        {
            return NotFound();
        }
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        bool isDeleted = _activityPlaceRepository.Delete(id);
        if (isDeleted == false)
        {
            return NotFound();
        }
        return NoContent();
    }
}
