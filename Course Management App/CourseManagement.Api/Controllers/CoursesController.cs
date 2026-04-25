using CourseManagement.Api.Models;
using CourseManagement.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly CourseStore _store;

    public CoursesController(CourseStore store)
    {
        _store = store;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Course>> GetAll()
    {
        return Ok(_store.GetAll());
    }

    [HttpPost]
    public ActionResult<Course> Create([FromBody] CourseCreateRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            return BadRequest("Title is required.");
        }

        if (string.IsNullOrWhiteSpace(request.Instructor))
        {
            return BadRequest("Instructor is required.");
        }

        if (request.Duration <= 0)
        {
            return BadRequest("Duration must be greater than 0.");
        }

        var created = _store.Add(request);
        return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var deleted = _store.Delete(id);
        return deleted ? NoContent() : NotFound();
    }
}
