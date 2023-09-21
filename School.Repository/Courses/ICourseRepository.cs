using School.Domain.Requests.Courses;
using School.Domain.Responses.Course;

namespace School.Repository.Cursos
{
    public interface ICourseRepository
    {
        ICollection<CourseResponse> GetAllCourses();

        CourseResponse PostCourse(CourseRequest request);
    }
}
