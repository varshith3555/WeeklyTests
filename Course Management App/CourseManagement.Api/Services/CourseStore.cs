using System.Collections.Concurrent;
using System.Threading;
using CourseManagement.Api.Models;

namespace CourseManagement.Api.Services;

public class CourseStore
{
    private readonly ConcurrentDictionary<int, Course> _courses = new();
    private int _nextId = 0;

    public CourseStore()
    {
        // Minimal seed data so the UI has something to display on first run.
        Add(new CourseCreateRequest { Title = "Angular Basics", Instructor = "Admin", Duration = 10 });
        Add(new CourseCreateRequest { Title = ".NET Core Web API", Instructor = "Admin", Duration = 12 });
    }

    public IReadOnlyCollection<Course> GetAll()
        => _courses.Values.OrderBy(c => c.Id).ToArray();

    public Course Add(CourseCreateRequest request)
    {
        var id = Interlocked.Increment(ref _nextId);
        var course = new Course
        {
            Id = id,
            Title = request.Title,
            Instructor = request.Instructor,
            Duration = request.Duration
        };

        _courses[id] = course;
        return course;
    }

    public bool Delete(int id)
        => _courses.TryRemove(id, out _);
}
