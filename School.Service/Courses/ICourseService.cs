using School.Domain.Responses.Course;

namespace School.Service.Courses
{
    public interface ICourseService
    {
        ICollection<CourseResponse> GetAllCourses();
    }
}
