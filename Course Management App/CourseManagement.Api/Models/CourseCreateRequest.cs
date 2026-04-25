namespace CourseManagement.Api.Models;

public class CourseCreateRequest
{
    public string Title { get; set; } = string.Empty;
    public string Instructor { get; set; } = string.Empty;
    public int Duration { get; set; } // in hours
}
