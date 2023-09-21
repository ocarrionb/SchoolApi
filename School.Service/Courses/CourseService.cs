using School.Domain.Responses.Course;
using School.Repository.Cursos;

namespace School.Service.Courses
{
    public sealed class CourseService : ICourseService
    {
        private readonly ICourseRepository _coursesRepository;
        public CourseService(ICourseRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }
        public ICollection<CourseResponse> GetAllCourses()
       {
            var listCoursesResponse = _coursesRepository.GetAllCourses();
            return listCoursesResponse;
       }
    }
}
